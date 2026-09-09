using NextTechStudentManagement.Models;
using NextTechStudentManagement.Repositories.Interface;
using NextTechStudentManagement.Services.Interface;

namespace NextTechStudentManagement.Services.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(
            IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(Student student)
        {
            await _studentRepository.AddAsync(student);
            await _studentRepository.SaveAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            await _studentRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _studentRepository.DeleteAsync(id);
            await _studentRepository.SaveAsync();
        }

        public async Task<IEnumerable<Student>> SearchAsync(
            string searchTerm)
        {
            return await _studentRepository.SearchAsync(searchTerm);
        }

        public async Task<IEnumerable<Student>> GetFilteredAsync(
            string? searchTerm = null,
            string? status = null,
            bool recent = false)
        {
            return await _studentRepository.GetFilteredAsync(
                searchTerm,
                status,
                recent);
        }
    }
}