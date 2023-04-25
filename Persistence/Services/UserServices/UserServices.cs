using HealthControlApp.API.Models.DomainModels;
using HealthControlApp.API.Models.MainModels;
using HealthControlApp.API.Persistence.Repositories.EmployRepository;
using HealthControlApp.API.Persistence.Repositories.RoleRepository;
using HealthControlApp.API.Persistence.Repositories.UserRepository;
using HealthControlApp.API.Persistence.Services.EmployServices;
using HealthControlApp.API.Persistence.Services.GroupServices;

namespace HealthControlApp.API.Persistence.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly IEmployServices _employServices;
        private readonly IRoleRepo _roleRepo;
        private readonly IUserRepo _userRepo;


        public UserServices(IEmployServices employServices, IRoleRepo roleRepo, IUserRepo userRepo)
        {
            _employServices = employServices;
            _roleRepo = roleRepo;
            _userRepo = userRepo;
        }
        public async Task<UserRepo> FindByIdAsync(int? userId)
        {
            User user = await _userRepo.FindByIdAsync(userId);
            
            EmployRepo employRepo = await _employServices.FindByIdAsync(user.IdEmploy);
            Role role = await _roleRepo.FindByIdAsync(user.IdRole);
            RoleRepo roleRepo = new RoleRepo();
            roleRepo.Id = role.Id;

            UserRepo userRepo = new UserRepo();
            userRepo.Id = user.Id;
            userRepo.Email = user.Email;

            userRepo.Employ = employRepo;
            userRepo.Role = roleRepo;
            userRepo.IsDeleted = user.IsDeleted;

            return userRepo;
        }

        public async Task<IEnumerable<UserRepo>> GetUsers()
        {
            IEnumerable<int> users = await _userRepo.GetAllId();
            List<UserRepo> usersRepo = new List<UserRepo>();

            foreach (int i in users)
            {
                usersRepo.Add(await FindByIdAsync(i));
            }
            return usersRepo;

        }
    }
}
