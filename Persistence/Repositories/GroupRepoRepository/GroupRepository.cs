using HealthControlApp.API.Models.DomainModels;
using HealthControlApp.API.Models.MainModels;
using HealthControlApp.API.Persistence.Contexts;

namespace HealthControlApp.API.Persistence.Repositories.GroupRepository
{
    public class GropuRepository : BaseRepository, IGroupRepo
    {
        public GropuRepository (AppDbContext appDbContext) : base (appDbContext) { }

        public Task AddAsync(GroupRepo groupRepo)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int groupId)
        {
            throw new NotImplementedException();
        }

        public async Task<Group> FindByIdAsync(int? groupId)
        {
            Group? _group = new Group();
            if (groupId != null)
            {
                _group = await _context.Groups.FindAsync(groupId);
            }
            return _group;
        }

        public Task<IEnumerable<int>> GetAllId()
        {
            throw new NotImplementedException();
        }

        public void Update(Group group)
        {
            throw new NotImplementedException();
        }
    }
}
