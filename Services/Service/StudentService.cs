namespace NextTechStudentManagement.Services.Service;
using NextTechStudentManagement.Models;
using NextTechStudentManagement.Repositories.Interface;
using NextTechStudentManagement.Services.Interface;


public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;

    public StudentService(IStudentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task CreateAsync(Student student)
    {
        await _repository.AddAsync(student);
        await _repository.SaveAsync();
    }

    public async Task UpdateAsync(Student student)
    {
        await _repository.UpdateAsync(student);
        await _repository.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
        await _repository.SaveAsync();
    }

    public async Task<IEnumerable<Student>> SearchAsync(string searchTerm)
    {
        return await _repository.SearchAsync(searchTerm);
    }
}