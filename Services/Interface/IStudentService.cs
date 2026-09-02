namespace NextTechStudentManagement.Services.Interface;
using NextTechStudentManagement.Models;


public interface IStudentService
{
    Task<IEnumerable<Student>> GetAllAsync();

    Task<Student?> GetByIdAsync(int id);

    Task CreateAsync(Student student);

    Task UpdateAsync(Student student);

    Task DeleteAsync(int id);

    Task<IEnumerable<Student>> SearchAsync(string searchTerm);
}