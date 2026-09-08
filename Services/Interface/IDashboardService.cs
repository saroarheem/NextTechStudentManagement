using NextTechStudentManagement.ViewModel;

namespace NextTechStudentManagement.Services.Interface
{
    public interface IDashboardService
    {
        Task<DashboardViewModel> GetDashboardAsync();
    }
}