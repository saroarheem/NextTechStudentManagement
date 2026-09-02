namespace NextTechStudentManagement.Repositories.Repo;

using NextTechStudentManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using NextTechStudentManagement.Data;
using NextTechStudentManagement.Models;


public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _context;

    public StudentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _context.Students.ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _context.Students.FindAsync(id);
    }

    public async Task AddAsync(Student student)
    {
        await _context.Students.AddAsync(student);
    }

    public async Task UpdateAsync(Student student)
    {
        _context.Students.Update(student);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var student = await _context.Students.FindAsync(id);

        if (student != null)
        {
            _context.Students.Remove(student);
        }
    }

    public async Task<IEnumerable<Student>> SearchAsync(string searchTerm)
    {
        return await _context.Students
            .Where(s =>
                s.StudentId.Contains(searchTerm) ||
                s.FullName.Contains(searchTerm) ||
                s.Email.Contains(searchTerm))
            .ToListAsync();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}