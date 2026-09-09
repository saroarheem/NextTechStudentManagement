using Microsoft.EntityFrameworkCore;
using NextTechStudentManagement.Data;
using NextTechStudentManagement.Models;
using NextTechStudentManagement.Repositories.Interface;

namespace NextTechStudentManagement.Repositories.Repo
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetAllAsync(int take)
        {
            return await _context.Students
                .OrderByDescending(s => s.CreatedAt)
                .Take(take)
                .ToListAsync();
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
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student != null)
            {
                _context.Students.Remove(student);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> SearchAsync(string searchTerm)
        {
            return await _context.Students
                .Where(s =>
                    s.StudentId.Contains(searchTerm) ||
                    s.FullName.Contains(searchTerm) ||
                    s.Email.Contains(searchTerm))
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _context.Students.CountAsync();
        }

        public async Task<int> GetCountByStatusAsync(string status)
        {
            return await _context.Students
                .CountAsync(s => s.Status == status);
        }

        public async Task<IEnumerable<Student>> GetByStatusAsync(
            string status,
            int take)
        {
            return await _context.Students
                .Where(s => s.Status == status)
                .OrderByDescending(s => s.CreatedAt)
                .Take(take)
                .ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetRecentAsync(int take)
        {
            var recentDate = DateTime.UtcNow.AddDays(-30);

            return await _context.Students
                .Where(s => s.CreatedAt >= recentDate)
                .OrderByDescending(s => s.CreatedAt)
                .Take(take)
                .ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetFilteredAsync(
            string? searchTerm = null,
            string? status = null,
            bool recent = false)
        {
            var query = _context.Students.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(s =>
                    s.StudentId.Contains(searchTerm) ||
                    s.FullName.Contains(searchTerm) ||
                    s.Email.Contains(searchTerm));
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                query = query.Where(s => s.Status == status);
            }

            if (recent)
            {
                var recentDate = DateTime.UtcNow.AddDays(-30);

                query = query.Where(s =>
                    s.CreatedAt >= recentDate);
            }

            return await query
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();
        }
    }
}