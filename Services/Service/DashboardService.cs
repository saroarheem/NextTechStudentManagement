using NextTechStudentManagement.Repositories.Interface;
using NextTechStudentManagement.Services.Interface;
using NextTechStudentManagement.ViewModel;

namespace NextTechStudentManagement.Services.Service
{
    public class DashboardService : IDashboardService
    {
        private readonly IStudentRepository _studentRepository;

        public DashboardService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<DashboardViewModel> GetDashboardAsync()
        {
            var model = new DashboardViewModel
            {
                TotalStudents = await _studentRepository.GetTotalCountAsync(),

                ActiveStudents = await _studentRepository.GetCountByStatusAsync("Active"),

                InactiveStudents = await _studentRepository.GetCountByStatusAsync("Inactive"),

                ActiveStudentList =
                    (await _studentRepository.GetByStatusAsync("Active", 5))
                    .ToList(),

                RecentStudents =
                    (await _studentRepository.GetRecentAsync(5))
                    .ToList(),

                InactiveStudentList =
                    (await _studentRepository.GetByStatusAsync("Inactive", 5))
                    .ToList(),

                AllStudentList =
                    (await _studentRepository.GetAllAsync(5))
                    .ToList()
            };

            return model;
        }
    }
}