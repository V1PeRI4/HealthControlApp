using HealthControlApp.API.Models.DomainModels;
using HealthControlApp.API.Models.MainModels;
using HealthControlApp.API.Persistence.Contexts;

namespace HealthControlApp.API.Persistence.Repositories.RoleRepository
{
    public class RoleRepository : BaseRepository, IRoleRepo
    {
        public RoleRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public Task AddAsync(RoleRepo role)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int roleId)
        {
            throw new NotImplementedException();
        }

        public async Task<Role> FindByIdAsync(int? roleId)
        {
            Role ? _role = new Role();
            if (roleId != null)
            {
                _role = await _context.Roles.FindAsync(roleId);
            }
            return _role;
        }

        public Task<IEnumerable<int>> GetAllId()
        {
            throw new NotImplementedException();
        }

        public void Update(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
