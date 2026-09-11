using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OpenCV
{
    public partial class Form1 : Form
    {
        private VideoCapture? _cap;
        private Bitmap? image;
        private Mat? _capturedFrame;
        private Mat? _capturedFaceMat;
        private System.Windows.Forms.Timer? _cameraTimer;
        private readonly FaceRecognitionService _faceService;
        private bool _isCameraRunning = false;
        private bool _isMatchedExisting = false;

        public Form1()
        {
            InitializeComponent();
            _faceService = new FaceRecognitionService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _cameraTimer = new System.Windows.Forms.Timer
            {
                Interval = 33 // approx 30 FPS
            };
            _cameraTimer.Tick += CameraTimer_Tick;
            UpdateStatusLabel("Status: Ready (Turn Camera ON)");
        }

        private void CameraTimer_Tick(object? sender, EventArgs e)
        {
            if (_cap != null && _cap.IsOpened())
            {
                using Mat frame = new Mat();
                _cap.Read(frame);
                if (!frame.Empty())
                {
                    var oldImage = pictureBox1.Image;
                    pictureBox1.Image = BitmapConverter.ToBitmap(frame);
                    oldImage?.Dispose();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_isCameraRunning)
                {
                    _cap = new VideoCapture(0);
                    if (!_cap.IsOpened())
                    {
                        MessageBox.Show("Could not access webcam.", "Camera Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    _cameraTimer?.Start();
                    _isCameraRunning = true;
                    button1.Text = "CAMERA ON (RUNNING)";
                    UpdateStatusLabel("Status: Live Stream Running");
                }
                else
                {
                    StopCamera();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error starting camera: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StopCamera()
        {
            _cameraTimer?.Stop();
            if (_cap != null && _cap.IsOpened())
            {
                _cap.Release();
                _cap.Dispose();
                _cap = null;
            }
            _isCameraRunning = false;
            button1.Text = "CAMERA ON / OFF";
            UpdateStatusLabel("Status: Camera Stopped");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear old inputs before processing new photo capture
                ResetFormInputFieldsOnly();
                _isMatchedExisting = false;
                button3.Enabled = true;
                button3.Text = "SUBMIT & SAVE";

                // Pause timer first so timer tick doesn't compete for webcam frames
                _cameraTimer?.Stop();

                using Mat frame = new Mat();

                bool tempOpened = false;
                if (_cap == null || !_cap.IsOpened())
                {
                    _cap = new VideoCapture(0);
                    tempOpened = true;
                }

                if (_cap != null && _cap.IsOpened())
                {
                    // Webcams often need a brief warm-up/retry loop when initializing or capturing
                    for (int retry = 0; retry < 10; retry++)
                    {
                        _cap.Read(frame);
                        if (!frame.Empty()) break;
                        System.Threading.Thread.Sleep(50);
                    }

                    if (!frame.Empty())
                    {
                        _capturedFrame?.Dispose();
                        _capturedFaceMat?.Dispose();

                        _capturedFrame = frame.Clone();
                        image = BitmapConverter.ToBitmap(_capturedFrame);
                        pictureBox1.Image = new Bitmap(image);

                        // Extract face and search database for matches
                        _capturedFaceMat = _faceService.CropAndNormalizeFace(_capturedFrame);
                        PersonRecord? matchedPerson = _faceService.MatchFace(_capturedFaceMat);

                        if (matchedPerson != null)
                        {
                            textBox1.Text = matchedPerson.FirstName;
                            textBox5.Text = matchedPerson.LastName;
                            textBox8.Text = matchedPerson.FatherName;
                            textBox7.Text = matchedPerson.CNIC;
                            textBox2.Text = matchedPerson.Regno;
                            textBox6.Text = matchedPerson.ContactNo;

                            _isMatchedExisting = true;
                            button3.Enabled = false;
                            button3.Text = "ALREADY REGISTERED";

                            UpdateStatusLabel("ALREADY REGISTERED - Record loaded below");
                            MessageBox.Show($"Person Recognized!\n\nThis person is ALREADY SAVED in database.\n\nName: {matchedPerson.FirstName} {matchedPerson.LastName}\nCNIC: {matchedPerson.CNIC}", "Match Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            _isMatchedExisting = false;
                            button3.Enabled = true;
                            button3.Text = "SUBMIT & SAVE";

                            UpdateStatusLabel("NEW PERSON - Not saved yet, please fill details");
                            MessageBox.Show("Photo Captured! New person detected.\n\nPlease fill out details and click SUBMIT & SAVE.", "New Person", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        if (_isCameraRunning && !tempOpened)
                        {
                            _cameraTimer?.Start();
                        }
                        MessageBox.Show("Frame capture failed. Please make sure no other app (Zoom, Teams, Skype, Browser) is using the webcam.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    if (tempOpened)
                    {
                        _cap.Release();
                        _cap.Dispose();
                        _cap = null;
                    }
                }
                else
                {
                    if (_isCameraRunning)
                    {
                        _cameraTimer?.Start();
                    }
                    MessageBox.Show("Camera not found or unavailable.", "Camera Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error capturing image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Safety net: even if this somehow gets triggered while a match was
            // found, refuse to create a duplicate record.
            if (_isMatchedExisting)
            {
                MessageBox.Show("This person is already registered. Nothing to save.", "Already Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string firstname = textBox1.Text.Trim();
            string lastname = textBox5.Text.Trim();
            string fathername = textBox8.Text.Trim();
            string CNIC = textBox7.Text.Trim();
            string Regno = textBox2.Text.Trim();
            string contactno = textBox6.Text.Trim();

            if (image == null || _capturedFrame == null)
            {
                MessageBox.Show("Please capture a photo first.", "Photo Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // BUG FIX (missing validation): CNIC used to be optional, so multiple
            // records could be saved with a blank or duplicate CNIC, making the
            // database unreliable. CNIC is now required, same as First/Last Name.
            if (string.IsNullOrWhiteSpace(firstname) || string.IsNullOrWhiteSpace(lastname) || string.IsNullOrWhiteSpace(CNIC))
            {
                MessageBox.Show("Please enter at least First Name, Last Name and CNIC.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // MISSING FEATURE ADDED: block duplicate CNIC even if face-matching
            // missed it (e.g. bad lighting angle during capture).
            var existingByCnic = _faceService.FindByCnic(CNIC);
            if (existingByCnic != null)
            {
                MessageBox.Show($"A person with this CNIC is already registered.\n\nName: {existingByCnic.FirstName} {existingByCnic.LastName}\nReg No: {existingByCnic.Regno}", "Duplicate CNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var record = new PersonRecord
                {
                    FirstName = firstname,
                    LastName = lastname,
                    FatherName = fathername,
                    CNIC = CNIC,
                    Regno = Regno,
                    ContactNo = contactno
                };

                _faceService.SaveRecord(record, _capturedFrame, _capturedFaceMat);
                UpdateStatusLabel("SAVED SUCCESSFULLY");
                MessageBox.Show($"Person record & face signature saved successfully!\n\nSaved to: {_faceService.StorageDirectory}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Show read-only Form2 summary card
                Form2 form2 = new Form2(firstname, lastname, fathername, CNIC, Regno, contactno, new Bitmap(image));
                form2.Show();

                // Automatically clear previous data from Form1 inputs for next person
                ResetFormFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatusLabel(string text)
        {
            // Plain, uncolored status text (no background/foreground color changes),
            // as requested - the wording itself communicates the state.
            lblStatus.Text = text;
        }

        private void ResetFormInputFieldsOnly()
        {
            textBox1.Clear();
            textBox5.Clear();
            textBox8.Clear();
            textBox7.Clear();
            textBox2.Clear();
            textBox6.Clear();
        }

        private void ResetFormFields()
        {
            ResetFormInputFieldsOnly();

            var oldImg = pictureBox1.Image;
            pictureBox1.Image = null;
            oldImg?.Dispose();

            image?.Dispose();
            image = null;

            _capturedFrame?.Dispose();
            _capturedFrame = null;

            _capturedFaceMat?.Dispose();
            _capturedFaceMat = null;

            _isMatchedExisting = false;
            button3.Enabled = true;
            button3.Text = "SUBMIT & SAVE";

            UpdateStatusLabel("Status: Ready for next entry");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopCamera();

            // Clean up any remaining native resources on exit.
            _capturedFrame?.Dispose();
            _capturedFaceMat?.Dispose();
            image?.Dispose();

            base.OnFormClosing(e);
        }
    }
}
