using NextTechStudentManagement.Models;
using NextTechStudentManagement.Models;

namespace NextTechStudentManagement.Repositories.Interface;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllAsync();

    Task<Student?> GetByIdAsync(int id);

    Task AddAsync(Student student);

    Task UpdateAsync(Student student);

    Task DeleteAsync(int id);

    Task SaveAsync();

    Task<IEnumerable<Student>> SearchAsync(string searchTerm);
}
