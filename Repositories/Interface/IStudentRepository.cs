using NextTechStudentManagement.Models;

namespace NextTechStudentManagement.Repositories.Interface
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();

        Task<IEnumerable<Student>> GetAllAsync(int take);

        Task<Student?> GetByIdAsync(int id);

        Task AddAsync(Student student);

        Task UpdateAsync(Student student);

        Task DeleteAsync(int id);

        Task SaveAsync();

        Task<IEnumerable<Student>> SearchAsync(string searchTerm);

        Task<int> GetTotalCountAsync();

        Task<int> GetCountByStatusAsync(string status);

        Task<IEnumerable<Student>> GetByStatusAsync(
            string status,
            int take);

        Task<IEnumerable<Student>> GetRecentAsync(int take);

        Task<IEnumerable<Student>> GetFilteredAsync(
            string? searchTerm = null,
            string? status = null,
            bool recent = false);
    }
}