using HealthControlApp.API.Models.DomainModels;
using HealthControlApp.API.Models.MainModels;

namespace HealthControlApp.API.Persistence.Repositories.RoleRepository
{
    public interface IRoleRepo
    {
        Task<Role> FindByIdAsync(int? roleId);
        Task<IEnumerable<int>> GetAllId();
        Task AddAsync(RoleRepo role);
        void Update(Role role);
        Task DeleteAsync(int roleId);
    }
}
