using NextTechStudentManagement.Models;

namespace NextTechStudentManagement.ViewModel
{
    public class DashboardViewModel
    {
        public int TotalStudents { get; set; }

        public int ActiveStudents { get; set; }

        public int InactiveStudents { get; set; }

        public List<Student> RecentStudents { get; set; }
    }
}
