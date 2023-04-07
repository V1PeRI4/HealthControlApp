using HealthControlApp.API.Models.MainModels;
using HealthControlApp.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HealthControlApp.API.Persistence.Repositories.HealthEmployStatusRepository
{
    public class HealthEmployStatusRepository : BaseRepository, IHealthEmployStatusRepo
    {
        public HealthEmployStatusRepository(AppDbContext context) : base(context)
        {
        }


        /*  FIND BY ID  */
        public async Task<HealthEmployStatus> FindByIdAsync(int? idStatus)
        {
            HealthEmployStatus? _status = new HealthEmployStatus();
            if (idStatus != null)
            {
                _status = await _context.HealthEmployStatuses.FindAsync(idStatus);
            }
            return _status;
        }

        public async Task<IEnumerable<HealthEmployStatus>> ListAsync()
        {
            return await _context.HealthEmployStatuses.ToListAsync();
        }

        public Task DeleteAsync(int statusId)
        {
            throw new NotImplementedException();
        }

    }

}
