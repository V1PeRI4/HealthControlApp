using HealthControlApp.API.Models.DomainModels;
using HealthControlApp.API.Models.MainModels;
using HealthControlApp.API.Persistence.Repositories.GroupRepository;
using HealthControlApp.API.Persistence.Repositories.MainGroupRepository;

namespace HealthControlApp.API.Persistence.Services.GroupServices
{
    public class GroupServices : IGroupServices
    {
        private readonly IGroupRepo _groupRepo;
        private readonly IMainGroupRepo _mainGroupRepo;


        public GroupServices(IGroupRepo groupRepo, IMainGroupRepo mainGroupRepo)
        {
            _groupRepo = groupRepo;
            _mainGroupRepo = mainGroupRepo;
        }

        public async Task<GroupRepo> FindByIdAsync(int? groupId)
        {
            Group group = await _groupRepo.FindByIdAsync(groupId);
            MainGroup mainGroup = await _mainGroupRepo.FindByIdAsync(group.IdMainGroup);

            MainGroupRepo mainGroupRepo = new MainGroupRepo();

            mainGroupRepo.Id = mainGroup.Id;
            mainGroupRepo.Name = mainGroup.Name;

            GroupRepo groupRepo = new GroupRepo();

            groupRepo.Id = group.Id;
            groupRepo.Name = group.Name;
            groupRepo.Description = group.Description;
            groupRepo.MainGroup = mainGroupRepo;

            return groupRepo;
        }

        public Task<IEnumerable<GroupRepo>> GetUser()
        {
            throw new NotImplementedException();
        }
    }
}
