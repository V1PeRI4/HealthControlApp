using HealthControlApp.API.Models.MainModels;
using HealthControlApp.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HealthControlApp.API.Persistence.Repositories.EmployRepository
{
    public class EmploysRepository : BaseRepository, IEmployRepo
    {
        public EmploysRepository(AppDbContext context) : base(context)
        {
        }

        /*  FIND BY ID  (не трогай)*/
        public async Task<Employ> FindByIdAsync(int? employId)
        {
            Employ? _employ = new Employ();
            if (employId != null)
            {
                _employ = await _context.Employ.FindAsync(employId);
            }
            return _employ;
        }

        /*  GET ALL EMPLOY  */
        public async Task<IEnumerable<int>> GetAllId()
        {
            var employList = await _context.Employ.ToListAsync();
            List<int> allId = new List<int>();
            employList.ForEach(e => { allId.Add(e.Id); });
            return allId;
        }

        /*  UPDATE  */
        public async void Update(Employ employ)
        {

            _context.Employ.Update(employ);
        }

        /*  ADD EMPLOY  */
        public async Task AddAsync(Employ _employ)
        {
            if (_employ.Id != 0)
            {
                try
                {
                    await _context.AddAsync(_employ);
                    await _context.SaveChangesAsync();

                }
                catch (Exception ex)
                {
                    throw;
                }

            }
            return;
        }

        /* 

                public Task AddAsync(EmployRepo employ)
                {
                    throw new NotImplementedException();
                }

         */

        /*  DEKETE EMPLOY  */
        public async Task DeleteAsync(int employId)
        {
            Employ _employ = await FindByIdAsync(employId);

            if (_employ != null)
            {
                try
                {
                    /*await*/
                    _context.Employ.Remove(_employ);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else { throw new NotImplementedException(); }

            return;
        }


    }
}



