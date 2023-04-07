using HealthControlApp.API.Models.DomainModels;
using HealthControlApp.API.Models.MainModels;

namespace HealthControlApp.API.Persistence.Repositories.GroupRepository
{
    public interface IGroupRepo
    {
        Task<Group> FindByIdAsync(int? mainGroup);
        Task<IEnumerable<int>> GetAllId();
        Task AddAsync(GroupRepo groupRepo);
        void Update(Group group);
        Task DeleteAsync(int groupId);
    }
}
