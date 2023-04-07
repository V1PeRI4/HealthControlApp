using HealthControlApp.API.Models.DomainModels;
using HealthControlApp.API.Models.MainModels;
using HealthControlApp.API.Persistence.Repositories.RoleRepository;
using HealthControlApp.API.Persistence.Repositories.UserRepository;
using HealthControlApp.API.Persistence.Services.EmployServices;
using HealthControlApp.API.Persistence.Services.GroupServices;

namespace HealthControlApp.API.Persistence.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly IGroupServices _groupServices;
        private readonly IEmployServices _employServices;
        private readonly IRoleRepo _roleRepo;
        private readonly IUserRepo _userRepo;


        public UserServices(IGroupServices groupSevices, IEmployServices employServices, IRoleRepo roleRepo, IUserRepo userRepo)
        {
            _groupServices = groupSevices;
            _employServices = employServices;
            _roleRepo = roleRepo;
            _userRepo = userRepo;
        }
        public async Task<UserRepo> FindByIdAsync(int? userId)
        {
            User user = await _userRepo.FindByIdAsync(userId);
            GroupRepo groupRepo = await _groupServices.FindByIdAsync(user.IdGroup);
            EmployRepo employRepo = await _employServices.FindByIdAsync(user.IdEmploy);
            Role role = await _roleRepo.FindByIdAsync(user.IdRole);
            RoleRepo roleRepo = new RoleRepo();
            roleRepo.Id = role.Id;

            UserRepo userRepo = new UserRepo();
            userRepo.Id = user.Id;
            userRepo.Login = user.Login;
            userRepo.Pass = user.Pass;
            userRepo.Group = groupRepo;
            userRepo.Employ = employRepo;
            userRepo.Role = roleRepo;
            userRepo.IsDeleted = user.IsDeleted;

            return userRepo;

        }

        public Task<IEnumerable<UserRepo>> GetUser()
        {
            throw new NotImplementedException();
        }
    }
}
