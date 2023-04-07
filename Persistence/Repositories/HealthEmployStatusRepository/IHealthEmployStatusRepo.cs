using HealthControlApp.API.Models.MainModels;

namespace HealthControlApp.API.Persistence.Repositories.HealthEmployStatusRepository
{
    public interface IHealthEmployStatusRepo
    {
        Task<HealthEmployStatus> FindByIdAsync(int? statusId);
        Task<IEnumerable<HealthEmployStatus>> ListAsync();
        Task DeleteAsync(int statusId);
    }
}
