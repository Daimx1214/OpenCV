# Face Recognition & Registration System

A Windows desktop application built with **C# (.NET 8, Windows Forms)** and **OpenCvSharp4** that captures a person's face from a webcam, automatically checks whether they are already registered, and — if not — lets you register them with their personal/academic details.

Useful for student verification desks, attendance/registration counters, or any small-scale face-based check-in system.

---

## Features

- **Live webcam preview** (~30 FPS) inside the app.
- **One-click photo capture** with automatic face detection (Haar Cascade).
- **Automatic recognition**: every captured face is compared against previously saved faces using histogram correlation + pixel difference scoring.
  - **Match found** → the person's saved details are loaded automatically and the Submit button is disabled (prevents duplicate records).
  - **No match** → treated as a new person; you fill in the details and save.
- **Duplicate protection**: in addition to face matching, CNIC is checked against existing records before saving, so the same person can't accidentally be registered twice.
- **Local storage**, no internet/database server required:
  - Cropped face image + full snapshot saved as `.jpg`
  - All records stored in `records.json`
  - Records also mirrored to `records.csv` (Excel-friendly)
- **Profile summary card** (`Form2`): a read-only "ID card" style window shown right after a successful registration.

---

## Tech Stack

| Component              | Technology                          |
|-------------------------|--------------------------------------|
| Language / Framework    | C# (.NET 8, Windows Forms)          |
| Computer Vision         | OpenCvSharp4                        |
| Face Detection          | Haar Cascade Classifier (`haarcascade_frontalface_default.xml`) |
| Data Storage            | JSON (`records.json`) + CSV (`records.csv`) |

---

## Project Structure

```
OpenCV/
├── Form1.cs / Form1.Designer.cs / Form1.resx   # Main window: camera, capture, registration form
├── Form2.cs / Form2.Designer.cs / Form2.resx   # Read-only profile summary card
├── FaceRecognitionService.cs                   # Face detection, matching, and save/load logic
├── PersonRecord.cs                              # Data model for a registered person
├── Program.cs                                    # App entry point
├── haarcascade_frontalface_default.xml          # Pre-trained OpenCV face detector
└── OpenCV.csproj                                 # Project file
```

---

## Getting Started

### Prerequisites
- Windows 10/11
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022 (recommended) with the **.NET Desktop Development** workload
- A working webcam

### Run it
1. Clone the repository:
   ```bash
   git clone https://github.com/Daimx1214/OpenCV.git
   ```
2. Open `OpenCV.sln` in Visual Studio.
3. Press **F5** to build and run (or `dotnet run` from the project folder).

### Where is my data saved?
All records, face images, and snapshots are saved under:
```
C:\Users\Daim Ali\OpenCV_Data\
├── Faces\          # Cropped face images
├── records.json    # All registered records
└── records.csv     # Same data, Excel-friendly
```

---

## How It Works

1. Turn the camera **ON**.
2. Click **CAPTURE PHOTO**.
   - The app detects and crops the face, then checks it against everyone already saved.
   - **Already registered?** Their details auto-fill and Submit is disabled — nothing more to do.
   - **New person?** The fields stay empty; fill them in.
3. Enter **First Name, Last Name, CNIC** (required) plus Father Name / Registration No / Contact No (optional).
4. Click **SUBMIT & SAVE**.
5. A profile summary card opens showing the saved record, and the form resets for the next person.

---

## Known Limitations

- Face matching uses classical computer vision (histogram + pixel difference), not a deep-learning embedding model — accuracy can vary with lighting/angle.
- Designed for a single local machine; there is no networked/multi-user database.
- Windows-only (Windows Forms + `OpenCvSharp4.Windows`).

---

## License

This project is open source and available under the [MIT License](LICENSE).
