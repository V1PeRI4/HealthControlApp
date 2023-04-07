using HealthControlApp.API.Models.DomainModels;
using HealthControlApp.API.Models.MainModels;

namespace HealthControlApp.API.Persistence.Repositories.MainGroupRepository
{
    public interface IMainGroupRepo
    {
        Task<MainGroup> FindByIdAsync(int? mainGroup);
        Task<IEnumerable<int>> GetAllId();
        Task AddAsync(MainGroupRepo groupRepo);
        void Update(MainGroup group);
        Task DeleteAsync(int groupId);
    }
}
