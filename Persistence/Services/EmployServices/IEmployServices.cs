using HealthControlApp.API.Models.DomainModels;

namespace HealthControlApp.API.Persistence.Services.EmployServices
{
    public interface IEmployServices
    {
        Task<EmployRepo> FindByIdAsync(int? employId);
        Task<IEnumerable<EmployRepo>> GetEmploys();


    }
}
