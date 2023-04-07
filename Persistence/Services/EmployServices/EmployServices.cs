using HealthControlApp.API.Models.DomainModels;
using HealthControlApp.API.Models.MainModels;
using HealthControlApp.API.Persistence.Repositories.EmployRepository;
using HealthControlApp.API.Persistence.Repositories.HealthEmployStatusRepository;


namespace HealthControlApp.API.Persistence.Services.EmployServices
{
    public class EmployServices : IEmployServices
    {
        private readonly IEmployRepo _employRepo;
        private readonly IHealthEmployStatusRepo _healthStatus;


        public EmployServices(IEmployRepo employRepo, IHealthEmployStatusRepo healthStatus)
        {
            _employRepo = employRepo;
            _healthStatus = healthStatus;
        }

        public async Task<EmployRepo> FindByIdAsync(int? employId)
        {
            Employ employ = await _employRepo.FindByIdAsync(employId);
            HealthEmployStatus heatlhEmployStatus = await _healthStatus.FindByIdAsync(employ.IdHealthEmployStatus);

            HealthEmployStatusRepo healthEmployStatusRepo = new HealthEmployStatusRepo();

            healthEmployStatusRepo.Id = heatlhEmployStatus.Id;
            healthEmployStatusRepo.HealthStatus = healthEmployStatusRepo.SetStatusRepo(heatlhEmployStatus.IdHealthStatus);
            healthEmployStatusRepo.Description = heatlhEmployStatus.Description;

            EmployRepo employRepo = new EmployRepo();

            employRepo.Id = employ.Id;
            employRepo.Name = employ.Name;
            employRepo.SurName = employ.SurName;
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
