using System;

namespace OpenCV
{
    public class PersonRecord
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string FatherName { get; set; } = "";
        public string CNIC { get; set; } = "";
        public string Regno { get; set; } = "";
        public string ContactNo { get; set; } = "";
        public string FaceImagePath { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
