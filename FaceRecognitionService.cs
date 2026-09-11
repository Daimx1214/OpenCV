using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace OpenCV
{
    public class FaceRecognitionService
    {
        private readonly string _storageDir;
        private readonly string _facesDir;
        private readonly string _dbFilePath;
        private readonly string _excelCsvPath;
        private readonly string _cascadePath;
        private readonly CascadeClassifier? _cascade;

        public FaceRecognitionService()
        {
            // IMPORTANT: This used to be a hardcoded path (C:\Users\Daim Ali\OpenCV_Data),
            // which only worked on one specific computer/user account. On any other PC,
            // or if that folder wasn't writable, saving would silently fail.
            // Using "My Documents" instead makes it work on any machine, for any user,
            // without needing Administrator rights.
            string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _storageDir = Path.Combine(documentsFolder, "OpenCV_Data");
            _facesDir = Path.Combine(_storageDir, "Faces");
            _dbFilePath = Path.Combine(_storageDir, "records.json");
            _excelCsvPath = Path.Combine(_storageDir, "records.csv");

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            _cascadePath = Path.Combine(baseDir, "haarcascade_frontalface_default.xml");

            if (!File.Exists(_cascadePath))
            {
                _cascadePath = Path.Combine(Directory.GetCurrentDirectory(), "haarcascade_frontalface_default.xml");
            }

            if (!File.Exists(_cascadePath))
            {
                var parent = Directory.GetParent(baseDir);
                while (parent != null)
                {
                    string candidate = Path.Combine(parent.FullName, "haarcascade_frontalface_default.xml");
                    if (File.Exists(candidate))
                    {
                        _cascadePath = candidate;
                        break;
                    }
                    parent = parent.Parent;
                }
            }

            Directory.CreateDirectory(_storageDir);
            Directory.CreateDirectory(_facesDir);

            // BUG FIX: previously a new CascadeClassifier was loaded from disk on every
            // single photo capture, which is slow and wasteful. It is now loaded ONCE
            // here and reused for the lifetime of the app.
            if (File.Exists(_cascadePath))
            {
                _cascade = new CascadeClassifier(_cascadePath);
            }
        }

        /// <summary>
        /// Full path to the folder where records/faces are stored. Exposed so the UI
        /// can tell the user exactly where their data is being saved.
        /// </summary>
        public string StorageDirectory => _storageDir;

        public Mat? CropAndNormalizeFace(Mat frame)
        {
            if (frame == null || frame.Empty()) return null;

            // BUG FIX: "gray" and "cropped" were never disposed before - every single
            // photo capture leaked native OpenCV memory. Now properly cleaned up.
            using Mat gray = new Mat();
            Cv2.CvtColor(frame, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.EqualizeHist(gray, gray);

            Rect faceRect;

            if (_cascade != null)
            {
                var faces = _cascade.DetectMultiScale(gray, 1.1, 4, HaarDetectionTypes.ScaleImage, new OpenCvSharp.Size(60, 60));

                if (faces.Length > 0)
                {
                    // Select largest face detected
                    faceRect = faces.OrderByDescending(r => r.Width * r.Height).First();
                }
                else
                {
                    // Fallback to central crop if no face boundary detected
                    int size = Math.Min(frame.Width, frame.Height) * 3 / 4;
                    faceRect = new Rect((frame.Width - size) / 2, (frame.Height - size) / 2, size, size);
                }
            }
            else
            {
                int size = Math.Min(frame.Width, frame.Height) * 3 / 4;
                faceRect = new Rect((frame.Width - size) / 2, (frame.Height - size) / 2, size, size);
            }

            using Mat cropped = new Mat(gray, faceRect);
            Mat normalizedFace = new Mat();
            Cv2.Resize(cropped, normalizedFace, new OpenCvSharp.Size(128, 128));
            return normalizedFace;
        }

        public PersonRecord? MatchFace(Mat? currentFaceMat)
        {
            if (currentFaceMat == null || currentFaceMat.Empty()) return null;

            var records = GetAllRecords();
            if (records.Count == 0) return null;

            using Mat currentHist = CalculateHistogram(currentFaceMat);

            PersonRecord? bestMatch = null;
            double highestScore = -1.0;

            foreach (var record in records)
            {
                if (!File.Exists(record.FaceImagePath)) continue;

                using Mat savedFaceMat = Cv2.ImRead(record.FaceImagePath, ImreadModes.Grayscale);
                if (savedFaceMat.Empty()) continue;

                using Mat savedNormalized = new Mat();
                Cv2.Resize(savedFaceMat, savedNormalized, new OpenCvSharp.Size(128, 128));

                using Mat savedHist = CalculateHistogram(savedNormalized);

                // Compare histograms using Correl method (higher = better match, max 1.0)
                double correlation = Cv2.CompareHist(currentHist, savedHist, HistCompMethods.Correl);

                // Pixel structural similarity (Mean Absolute Error)
                using Mat diff = new Mat();
                Cv2.Absdiff(currentFaceMat, savedNormalized, diff);
                double meanDiff = Cv2.Mean(diff).Val0; // Lower mean diff = closer match

                // Combined score
                if (correlation > 0.70 && meanDiff < 45.0)
                {
                    if (correlation > highestScore)
                    {
                        highestScore = correlation;
                        bestMatch = record;
                    }
                }
            }

            return bestMatch;
        }

        private Mat CalculateHistogram(Mat grayMat)
        {
            Mat hist = new Mat();
            int[] histSize = { 256 };
            Rangef[] ranges = { new Rangef(0, 256) };
            int[] channels = { 0 };

            Cv2.CalcHist(new Mat[] { grayMat }, channels, null, hist, 1, histSize, ranges);
            Cv2.Normalize(hist, hist, 0, 1, NormTypes.MinMax);
            return hist;
        }

        public List<PersonRecord> GetAllRecords()
        {
            if (!File.Exists(_dbFilePath)) return new List<PersonRecord>();

            try
            {
                string json = File.ReadAllText(_dbFilePath);
                return JsonSerializer.Deserialize<List<PersonRecord>>(json) ?? new List<PersonRecord>();
            }
            catch
            {
                return new List<PersonRecord>();
            }
        }

        /// <summary>
        /// MISSING FEATURE ADDED: checks whether a CNIC is already registered.
        /// This catches duplicates even in the rare case the face-matching algorithm
        /// misses a match (bad lighting, angle, etc.) - CNIC is unique per person.
        /// </summary>
        public PersonRecord? FindByCnic(string cnic)
        {
            if (string.IsNullOrWhiteSpace(cnic)) return null;
            return GetAllRecords().FirstOrDefault(r =>
                string.Equals(r.CNIC?.Trim(), cnic.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public string SaveRecord(PersonRecord record, Mat? fullFrame, Mat? faceMat)
        {
            var records = GetAllRecords();

            // Save cropped face image
            string faceFileName = $"{record.Id}.jpg";
            string faceFilePath = Path.Combine(_facesDir, faceFileName);
            if (faceMat != null && !faceMat.Empty())
            {
                Cv2.ImWrite(faceFilePath, faceMat);
            }
            else if (fullFrame != null && !fullFrame.Empty())
            {
                Cv2.ImWrite(faceFilePath, fullFrame);
            }

            record.FaceImagePath = faceFilePath;

            // BUG FIX: FirstName/LastName were used directly inside a file name.
            // If a user typed a character like \ / : * ? " < > | (even by accident),
            // saving would throw an exception and the record wouldn't save at all.
            // Now the name is sanitized before being used in a file path.
            string safeFirst = SanitizeForFileName(record.FirstName);
            string safeLast = SanitizeForFileName(record.LastName);

            // Also save snapshot picture in desktop folder
            string snapshotName = $"snapShot_{safeFirst}_{safeLast}_{DateTime.Now:yyyyMMdd_HHmmss}.jpg";
            string snapshotPath = Path.Combine(_storageDir, snapshotName);
            if (fullFrame != null && !fullFrame.Empty())
            {
                Cv2.ImWrite(snapshotPath, fullFrame);
            }

            records.Add(record);

            // 1. Save to JSON
            string updatedJson = JsonSerializer.Serialize(records, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_dbFilePath, updatedJson);

            // 2. Export/Sync to Excel CSV
            ExportToExcelCsv(records);

            return snapshotPath;
        }

        private void ExportToExcelCsv(List<PersonRecord> records)
        {
            try
            {
                using var writer = new StreamWriter(_excelCsvPath, false, Encoding.UTF8);
                writer.WriteLine("ID,First Name,Last Name,Father Name,CNIC,Registration No,Contact No,Date Created,Face Image Path");

                foreach (var r in records)
                {
                    string line = $"\"{EscapeCsv(r.Id)}\",\"{EscapeCsv(r.FirstName)}\",\"{EscapeCsv(r.LastName)}\",\"{EscapeCsv(r.FatherName)}\",\"{EscapeCsv(r.CNIC)}\",\"{EscapeCsv(r.Regno)}\",\"{EscapeCsv(r.ContactNo)}\",\"{r.CreatedAt:yyyy-MM-dd HH:mm:ss}\",\"{EscapeCsv(r.FaceImagePath)}\"";
                    writer.WriteLine(line);
                }
            }
            catch
            {
                // Handle file locking gracefully
            }
        }

        private string EscapeCsv(string input)
        {
            if (string.IsNullOrEmpty(input)) return "";
            return input.Replace("\"", "\"\"");
        }

        private string SanitizeForFileName(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return "Unknown";
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                input = input.Replace(c, '_');
            }
            return input.Trim();
        }
    }
}
