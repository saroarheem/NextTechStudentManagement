
namespace NextTechStudentManagement.Controllers;

using NextTechStudentManagement.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using NextTechStudentManagement.Models;

public class StudentController : Controller
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public async Task<IActionResult> Index(string searchTerm)
    {
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            var result = await _studentService.SearchAsync(searchTerm);
            return View(result);
        }

        var students = await _studentService.GetAllAsync();

        return View(students);
    }

    public async Task<IActionResult> Details(int id)
    {
        var student = await _studentService.GetByIdAsync(id);

        if (student == null)
            return NotFound();

        return View(student);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Student student)
    {
        if (!ModelState.IsValid)
            return View(student);

        await _studentService.CreateAsync(student);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var student = await _studentService.GetByIdAsync(id);

        if (student == null)
            return NotFound();

        return View(student);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Student student)
    {
        if (!ModelState.IsValid)
            return View(student);

        await _studentService.UpdateAsync(student);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var student = await _studentService.GetByIdAsync(id);

        if (student == null)
            return NotFound();

        return View(student);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _studentService.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }
}