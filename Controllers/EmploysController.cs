using System;
using Microsoft.AspNetCore.Mvc;
using HealthControlApp.API.Extensions;
using HealthControlApp.API.Persistence.Repositories.EmployRepository;
using HealthControlApp.API.Persistence.Services.EmployServices;
using HealthControlApp.API.Models.MainModels;
using HealthControlApp.API.Models.DomainModels;

namespace HealthControlApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmploysController : ControllerBase
    {
        private readonly IEmployRepo _employRepo;
        private readonly IEmployServices _employServices;

        public EmploysController(IEmployRepo employRepo, IEmployServices employServices)
        {
            _employRepo = employRepo;
            _employServices = employServices;
        }


        [HttpGet]
        public async Task<IEnumerable<EmployRepo>> ListAsync()
        {
            return await _employServices.GetEmploys();
        }

        [HttpPost]
        [Route("test")]
        public async Task<IActionResult> GetEmptyEmploy(EmployRequest employRequest)
        {
            await _employRepo.AddAsync(_employRepo.GetEmptyEmploy(employRequest));
            return Ok();
        }

        [HttpPost]
        [Route("add")]

        public async Task<IActionResult> AddAsync(Employ employ)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            await _employRepo.AddAsync(employ);
            return Ok();
        }

        [HttpPost]
        [Route("addEmpty")]
        public async Task<IActionResult> AddEmptyEmployAsync(EmployRequest employ)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            Employ _employ = _employRepo.GetEmptyEmploy(employ);
            await AddAsync(_employ);
            return Ok(_employ.Id);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int employId)
        {
            try
            {
                await _employRepo.DeleteAsync(employId);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest(ModelState.GetErrorMessages());
            }
        }

        /*  Гет запрос от сервиса Employ (в себя включает данные Employ и HealthEmployStatus)     */
        [HttpGet("{employId}")]
        public async Task<EmployRepo> FindByIdAsync(string employId)
        {
            return await _employServices.FindByIdAsync(int.Parse(employId));
        }



    }
}
