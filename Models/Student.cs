using System.ComponentModel.DataAnnotations;

namespace NextTechStudentManagement.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string StudentId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Course { get; set; }
        [Required]
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
