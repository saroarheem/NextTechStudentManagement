
namespace NextTechStudentManagement.Controllers;
using Microsoft.AspNetCore.Mvc;
using NextTechStudentManagement.Data;
using NextTechStudentManagement.ViewModel;

public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new DashboardViewModel
            {
                TotalStudents = _context.Students.Count(),

                ActiveStudents = _context.Students.Count(s => s.Status == "Active"),

                InactiveStudents = _context.Students.Count(s => s.Status == "Inactive"),

                RecentStudents = _context.Students
                    .OrderByDescending(s => s.CreatedAt)
                    .Take(5)
                    .ToList()
            };

            return View(model);
        }
    }
