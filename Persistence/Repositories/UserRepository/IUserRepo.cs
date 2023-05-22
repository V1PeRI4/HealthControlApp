using HealthControlApp.API.Models.DomainModels;
using HealthControlApp.API.Models.MainModels;
using Microsoft.AspNetCore.Mvc;

namespace HealthControlApp.API.Persistence.Repositories.UserRepository
{
    public interface IUserRepo
    {
        Task<User> FindByIdAsync(int? userId);
        Task<IEnumerable<int>> GetAllId();
        Task AddAsync(User userRepo);
        User GetEmptyAsync(UserRequest userRequest);
        void UpdateUser(User user);
        Task DeleteAsync(int userId);
        Task<IEnumerable<UserRepo>> GetUser();
        Task ChangeNameUser(int idUser, string newName);
        Task ChangeHealthStatusUser(int id, int idNewStatus);
    }
}
