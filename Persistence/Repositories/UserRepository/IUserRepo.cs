using HealthControlApp.API.Models.DomainModels;
using HealthControlApp.API.Models.MainModels;

namespace HealthControlApp.API.Persistence.Repositories.UserRepository
{
    public interface IUserRepo
    {
        Task<User> FindByIdAsync(int? userId);
        Task<IEnumerable<int>> GetAllId();
        Task AddAsync(UserRepo userRepo);
        void Update(User user);
        Task DeleteAsync(int userId);
        Task<IEnumerable<EmployRepo>> GetEmploys();
    }
}
