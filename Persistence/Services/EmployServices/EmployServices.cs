using HealthControlApp.API.Models.DomainModels;
using HealthControlApp.API.Models.MainModels;
using HealthControlApp.API.Persistence.Repositories.EmployRepository;
using HealthControlApp.API.Persistence.Repositories.HealthEmployStatusRepository;
using HealthControlApp.API.Persistence.Repositories.UserRepository;
using HealthControlApp.API.Persistence.Services.GroupServices;

namespace HealthControlApp.API.Persistence.Services.EmployServices
{
    public class EmployServices : IEmployServices
    {
        private readonly IEmployRepo _employRepo;
        private readonly IHealthEmployStatusRepo _healthStatus;
        private readonly IGroupServices _groupServices;



        public EmployServices(IEmployRepo employRepo, IHealthEmployStatusRepo healthStatus, IGroupServices groupServices)
        {
            _employRepo = employRepo;
            _healthStatus = healthStatus;
            _groupServices = groupServices;
        }

        public async Task<EmployRepo> FindByIdAsync(int? employId)
        {
            Employ employ = await _employRepo.FindByIdAsync(employId);
            HealthEmployStatus heatlhEmployStatus = await _healthStatus.FindByIdAsync(employ.IdHealthEmployStatus);

            HealthEmployStatusRepo healthEmployStatusRepo = new HealthEmployStatusRepo();

            healthEmployStatusRepo.Id = heatlhEmployStatus.Id;
            healthEmployStatusRepo.HealthStatus = healthEmployStatusRepo.SetStatusRepo(heatlhEmployStatus.IdHealthStatus);
            healthEmployStatusRepo.Description = heatlhEmployStatus.Description;

            GroupRepo groupRepo = await _groupServices.FindByIdAsync(employ.IdGroup);

            EmployRepo employRepo = new EmployRepo();

            employRepo.Id = employ.Id;
            employRepo.Name = employ.Name;
            employRepo.LastName = employ.LastName;
            employRepo.FatherName = employ.FatherName;
            employRepo.Group = groupRepo;
            employRepo.HealthEmployStatus = healthEmployStatusRepo;

            return employRepo;
        }

        public async Task<IEnumerable<EmployRepo>> GetEmploys()
        {
            IEnumerable<int> employs = _employRepo.GetAllId().Result;
            List<EmployRepo> employsRepo = new List<EmployRepo>();

            foreach (int i in employs)
            {
                employsRepo.Add(await FindByIdAsync(i));
            }
            return employsRepo;

        }


    }
}
