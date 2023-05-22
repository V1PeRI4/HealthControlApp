using HealthControlApp.API.Extensions;
using HealthControlApp.API.Models.DomainModels;
using HealthControlApp.API.Models.MainModels;
using HealthControlApp.API.Persistence.Contexts;
using HealthControlApp.API.Persistence.Query;
using HealthControlApp.API.Persistence.Repositories.UserRepository;
using HealthControlApp.API.Persistence.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthControlApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IUserRepo _userRepo;
        private readonly AppDbContext _appDbContext;

        public UserController(IUserServices userServices, IUserRepo user, AppDbContext appDbContext)
        {
            _userServices = userServices;
            _userRepo = user;
            _appDbContext = appDbContext; 
        }

        [HttpGet("{userId}"), Authorize]
        
        public async Task<UserRepo> FindByIdAsync(int? userId)
        {
            return await _userServices.FindByIdAsync(userId);
        }
        [HttpGet, Authorize]
        [Route("getAllUser")]
        public async Task<IEnumerable<UserRepo>> GetAllAsync()
        {
            return await _userServices.GetUsers();
        }

        [HttpPost, Authorize] 
        [Route("postUser")]
        public async Task<IActionResult> AddUser(User user)
        {
            if (user == null) 
            {
                return BadRequest();
            }
            await _userRepo.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete]
        [Route("deleteUser")]

        public async Task<IActionResult> Delete(int employId)
        {
            try
            {
                await _userRepo.DeleteAsync(employId);
                await _appDbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
        }


        [HttpPut]
        [Route("changeName")]
        public async Task<IActionResult> ChangeUserName(ChangeNameRequest changeNameRequest)
        {
            try
            {
                await _userRepo.ChangeNameUser(changeNameRequest.id, changeNameRequest.newName);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
        }

        [HttpPut]
        [Route("changeHealthStatus")]
        public async Task<IActionResult> ChangeHealthStatus(ChangeHealthStatusRequest changeHealthStatusRequest)
        {
            try
            {
                await _userRepo.ChangeHealthStatusUser(changeHealthStatusRequest.id, changeHealthStatusRequest.idNewStatus);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
        }
    }
}
