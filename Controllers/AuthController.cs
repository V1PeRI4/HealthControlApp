using HealthControlApp.API.Models.DomainModels;
using HealthControlApp.API.Models.MainModels;
using HealthControlApp.API.Persistence.Contexts;
using HealthControlApp.API.Persistence.QueryResults;
using HealthControlApp.API.Persistence.Repositories.EmployRepository;
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
        private readonly IEmployRepo _employRepo;
        private readonly IUserRepo _userRepo;
        /*private readonly EmploysRepository _employsRepository;*/
        /*private readonly UserRepository _userRepository;*/
        public AuthController(
            UserManager<IdentityUser> userManager,
            AppDbContext context,
            TokenService tokenService,
            IUserServices userServices,
            IEmployRepo employRepo,
            IUserRepo userRepo
            /*EmploysRepository employsRepository,*/
            /*UserRepository userRepository*/
            )
        {
            _userManager = userManager;
            _context = context;
            _tokenService = tokenService;
            _userServices = userServices;
            _employRepo = employRepo;
            _userRepo = userRepo;
            /*_employsRepository = employsRepository;*/
            /*_userRepository = userRepository;*/
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

            var employ = new EmployRequest {
                Name = registrationRequest.Name,
                FatherName = registrationRequest.FatherName,
                LastName = registrationRequest.LastName
            };

            string name;

            /* проблема в том, что ниже метод должен быть ассинхронным,
               а с него нужно получить id еще ниже в конструктор узера */

            await _employRepo.AddAsync(_employRepo.GetEmptyEmploy(employ));

            await _userRepo.AddAsync(
                    new User
                    {
                        IdEmploy = ,
                        Email = registrationRequest.Email,
                        IdRole = 0,
                        IsDeleted = false,
                    }
                );


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
                Username = _userServices.FindByIdAsync(userInDb.IdEmploy).Result.Employ.Name,
                Email = userInDb.Email,
                Token = accessToken,
            }) ;
        }
    }
}