using HealthControlApp.API.Models.MainModels;

namespace HealthControlApp.API.Persistence.Repositories.EmployRepository
{
    public interface IEmployRepo
    {
        Task<Employ> FindByIdAsync(int? employId);
        Task<IEnumerable<int>> GetAllId();
        Task AddAsync(Employ employ);
        void Update(Employ employ);
        Task DeleteAsync(int employId);
    }
}
