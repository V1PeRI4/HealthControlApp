using HealthControlApp.API.Models.DomainModels;
using HealthControlApp.API.Models.MainModels;
using HealthControlApp.API.Persistence.Contexts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting.Hosting;
using Microsoft.EntityFrameworkCore;

namespace HealthControlApp.API.Persistence.Repositories.UserRepository
{
    public class UserRepository : BaseRepository, IUserRepo
    {
        public UserRepository(AppDbContext appDbContext): base(appDbContext) { }

        public async Task AddAsync(User _user)
        {
            try
            {
                await _context.AddAsync(_user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return;
        }

        public User GetEmptyAsync(UserRequest userRequest)
        {
            User user = new User()
            {
                email = userRequest.Email, //Email
                IdRole = 0,
                IsDeleted = false
            };

            return user;
        }

        public Task DeleteAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByIdAsync(int? userId)
        {
            User? _user = new User();
            if (userId != null)
            {
                _user = await _context.Users.FindAsync(userId);
            }
            return _user;
        }

        public async Task<IEnumerable<int>> GetAllId()
        {
            var userList = await _context.Users.ToListAsync();
            List<int> allId = new List<int>();
            userList.ForEach(e => { allId.Add(e.Id); }); //Id
            return allId;
        }

        public Task<IEnumerable<UserRepo>> GetUser()
        {
            throw new NotImplementedException();
        }

        public async void UpdateUser(User user)
        {
            try
            {
                _context.Users.Update(user);
                
            }
            catch (Exception ex)
            {
                throw;
            }
            return;
        }

        public async Task ChangeNameUser(int id, string newName)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.Name = newName;
                await _context.SaveChangesAsync();
            } 
        }

        public async Task ChangeHealthStatusUser(int id, int idNewStatus)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.IdHealthStatus = idNewStatus;
                await _context.SaveChangesAsync();
            }
        }

    }
}
