using System.ComponentModel.DataAnnotations;

namespace CodefirstSchoolManagement.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(50)]
        public string Subject { get; set; }

        // Navigation Property: One Teacher → Many Students
        public IList<Student> Students { get; set; }
       

    }
}
