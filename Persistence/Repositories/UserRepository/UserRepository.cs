using HealthControlApp.API.Models.DomainModels;
using HealthControlApp.API.Models.MainModels;
using HealthControlApp.API.Persistence.Contexts;

namespace HealthControlApp.API.Persistence.Repositories.UserRepository
{
    public class UserRepository : BaseRepository, IUserRepo
    {
        public UserRepository(AppDbContext appDbContext): base(appDbContext) { }

        public Task AddAsync(UserRepo userRepo)
        {
            throw new NotImplementedException();
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

        public Task<IEnumerable<int>> GetAllId()
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
