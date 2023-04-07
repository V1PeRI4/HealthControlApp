using HealthControlApp.API.Models.DomainModels;

namespace HealthControlApp.API.Persistence.Services.UserServices
{
    public interface IUserServices
    {
        Task<UserRepo> FindByIdAsync(int? userId);
        Task<IEnumerable<UserRepo>> GetUser();
    }
}
