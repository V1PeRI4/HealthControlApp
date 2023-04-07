using HealthControlApp.API.Models.DomainModels;
using HealthControlApp.API.Persistence.Services.EmployServices;
using Microsoft.AspNetCore.Mvc;

namespace HealthControlApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployServicesController : ControllerBase
    {
        private readonly IEmployServices _dbEmploy;

        public EmployServicesController(IEmployServices dbEmploy)
        {
            _dbEmploy = dbEmploy;
        }

        [HttpGet]
        public async Task<EmployRepo> FindByIdAsync(int? employId)
        {
            return await _dbEmploy.FindByIdAsync(employId);
        }
    }
}
