using HealthControlApp.API.Models.MainModels;
using HealthControlApp.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace HealthControlApp.API.Persistence.Repositories.EmployRepository
{
    public class EmploysRepository : BaseRepository, IEmployRepo
    {
        public EmploysRepository(AppDbContext context) : base(context)
        {
        }

        /*  FIND BY ID  */
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
        public async Task<int> AddAsync(Employ _employ)
        {
            var test = await _context.AddAsync(_employ);
            try
            {
               

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return test.;
        }

        public Employ GetEmptyEmploy(EmployRequest employRequest)
            {
            Employ employ = new Employ() {  
                Name = employRequest.Name, 
                LastName = employRequest.LastName,
                FatherName = employRequest.FatherName
            };

            return employ;
        }

        /*  DELETE EMPLOY  */
        public async Task DeleteAsync(int employId)
        {
            Employ _employ = await FindByIdAsync(employId);

            if (_employ != null)
            {
                try
                {
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



