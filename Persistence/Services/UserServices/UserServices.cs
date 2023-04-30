using HealthControlApp.API.Models.DomainModels;
using HealthControlApp.API.Models.MainModels;
using HealthControlApp.API.Persistence.Repositories.GroupRepository;
using HealthControlApp.API.Persistence.Repositories.HealthEmployStatusRepository;
using HealthControlApp.API.Persistence.Repositories.MainGroupRepository;
using HealthControlApp.API.Persistence.Repositories.RoleRepository;
using HealthControlApp.API.Persistence.Repositories.UserRepository;
using HealthControlApp.API.Persistence.Services.GroupServices;

namespace HealthControlApp.API.Persistence.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly IRoleRepo _roleRepo;
        private readonly IUserRepo _userRepo;
        private readonly IGroupRepo _groupRepo;
        private readonly IHealthEmployStatusRepo _healthEmployStatusRepo;
        private readonly IMainGroupRepo _mainGroupRepo;


        public UserServices( 
            IRoleRepo roleRepo, 
            IUserRepo userRepo, 
            IGroupRepo groupRepo, 
            IHealthEmployStatusRepo healthEmployStatusRepo, 
            IMainGroupRepo mainGroupRepo
            )
        {
            _roleRepo = roleRepo;
            _userRepo = userRepo;
            _groupRepo = groupRepo;
            _healthEmployStatusRepo = healthEmployStatusRepo;
            _mainGroupRepo = mainGroupRepo;
        }
        public async Task<UserRepo> FindByIdAsync(int? userId)
        {
            User user = await _userRepo.FindByIdAsync(userId);
            Role role = await _roleRepo.FindByIdAsync(user.IdRole);
            Group group = await _groupRepo.FindByIdAsync(user.IdGroup);
            MainGroup mainGroup = await _mainGroupRepo.FindByIdAsync(group.IdMainGroup);
            HealthEmployStatus healthEmployStatus = await _healthEmployStatusRepo.FindByIdAsync(user.IdHealthEmployStatus);
            
            RoleRepo roleRepo           = new RoleRepo()      { Id = role.Id};
            MainGroupRepo mainGroupRepo = new MainGroupRepo() { Id = mainGroup.Id, Name = mainGroup.Name };
            GroupRepo groupRepo         = new GroupRepo()
            {
                Id = group.Id,
                Description = group.Description,
                MainGroup = mainGroupRepo, 
                Name = group.Name
            };
            HealthEmployStatusRepo healthEmployStatusRepo = new HealthEmployStatusRepo()
            {
                Id = healthEmployStatus.Id,
                Description = healthEmployStatus.Description,
            };


            UserRepo userRepo = new UserRepo()
            {
                Id = user.IdRole,
                Name = user.Name,
                Email = user.Email,
                FatherName = user.FatherName,
                LastName = user.LastName,
                Group = groupRepo,
                HealthEmployStatus = healthEmployStatusRepo,
                Role = roleRepo,
                IsDeleted = user.IsDeleted,
            };
  
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
