using Microsoft.AspNetCore.Mvc;

namespace NextTechStudentManagement.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
