using HealthControlApp.API.Models.DomainModels;
using HealthControlApp.API.Models.MainModels;
using HealthControlApp.API.Persistence.Contexts;
using HealthControlApp.API.Persistence.QueryResults;
using HealthControlApp.API.Persistence.Repositories.UserRepository;
using HealthControlApp.API.Persistence.Services;
using HealthControlApp.API.Persistence.Services.UserServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthControlApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;
        private readonly IUserServices _userServices;
        private readonly IUserRepo _userRepo;

        public AuthController(
            UserManager<IdentityUser> userManager,
            AppDbContext context,
            TokenService tokenService,
            IUserServices userServices,
            IUserRepo userRepo
            )
        {
            _userManager = userManager;
            _context = context;
            _tokenService = tokenService;
            _userServices = userServices;
            _userRepo = userRepo;
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegistrationRequest registrationRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userManager.CreateAsync(
                new IdentityUser { 
                    UserName = registrationRequest.Username, 
                    Email = registrationRequest.Email 
                },
                registrationRequest.Password
            );

            await _userRepo.AddAsync(
                    new User
                    {
                        Email = registrationRequest.Email,
                        Name = registrationRequest.Name,
                        LastName = registrationRequest.LastName,
                        FatherName = registrationRequest.FatherName,
                        IdGroup = 0,
                        IdHealthEmployStatus = 0,
                        IdRole = 0,
                        IsDeleted = false,
                    }
                ) ;

            if (result.Succeeded)
            {
                registrationRequest.Password = "";
                return CreatedAtAction(nameof(Register), new { email = registrationRequest.Email }, registrationRequest);
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthResponse>> Authentication([FromBody] AuthRequest request)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var managedUser = await _userManager.FindByEmailAsync(request.Email);
            if (managedUser == null)
                return BadRequest("Bad credentials");

            var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password);
            if (!isPasswordValid)
                return BadRequest("Bad credentials");

            var userInDb = _context.Users.FirstOrDefault(u => u.Email == request.Email);
            if (userInDb is null)
                return Unauthorized();

            var accessToken = _tokenService.CreateToken(managedUser);  
            await _context.SaveChangesAsync();
            return Ok(new AuthResponse
            {
                Username = userInDb.Name,
                Email = userInDb.Email,
                Token = accessToken,
            }) ;
        }
    }
}