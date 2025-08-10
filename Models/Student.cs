using System.ComponentModel.DataAnnotations;

namespace CodefirstSchoolManagement.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        public int Age { get; set; }

        // Foreign Key
        public int TeacherId { get; set; }

        // Navigation Property
        public Teacher Teacher { get; set; }
    }
}
