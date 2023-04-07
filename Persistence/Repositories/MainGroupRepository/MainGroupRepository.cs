using HealthControlApp.API.Models.DomainModels;
using HealthControlApp.API.Models.MainModels;
using HealthControlApp.API.Persistence.Contexts;

namespace HealthControlApp.API.Persistence.Repositories.MainGroupRepository
{
    public class MainGroupRepository : BaseRepository, IMainGroupRepo
    {
        public MainGroupRepository(AppDbContext context) : base(context)
        {
        }
        public Task AddAsync(MainGroupRepo groupRepo)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int groupId)
        {
            throw new NotImplementedException();
        }

        public async Task<MainGroup> FindByIdAsync(int? mainGroup)
        {
            MainGroup? _group = new MainGroup();
            if (mainGroup!= null)
            {
                _group = await _context.MainGroups.FindAsync(mainGroup);
            }
            return _group;
        }

        public Task<IEnumerable<int>> GetAllId()
        {
            throw new NotImplementedException();
        }

        public void Update(MainGroup group)
        {
            throw new NotImplementedException();
        }
    }
}
