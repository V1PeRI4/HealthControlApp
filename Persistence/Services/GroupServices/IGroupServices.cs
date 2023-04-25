using HealthControlApp.API.Models.DomainModels;

namespace HealthControlApp.API.Persistence.Services.GroupServices
{
    public interface IGroupServices
    {
        Task<GroupRepo> FindByIdAsync(int? groupId);
        Task<IEnumerable<GroupRepo>> GetUser();
    }
}
