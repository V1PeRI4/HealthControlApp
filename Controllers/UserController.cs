using HealthControlApp.API.Models.DomainModels;
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

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("{userId}"), Authorize]
        public Task<UserRepo> FindByIdAsync(int? userId)
        {
            return _userServices.FindByIdAsync(userId);
        }

        [HttpGet]
        public Task<IEnumerable<UserRepo>> GetAllAsync()
        {
            return _userServices.GetUsers();
        }
    }
}
