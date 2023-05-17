using HealthControlApp.API.Models.DomainModels;
using HealthControlApp.API.Models.MainModels;
using HealthControlApp.API.Persistence.Contexts;
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

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
