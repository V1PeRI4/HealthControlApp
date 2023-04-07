
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthControlApp.API.Persistence.Repositories.HealthEmployStatusRepository;
using HealthControlApp.API.Models.MainModels;

namespace HealthControlApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthEmployStatusController : ControllerBase
    {
        private readonly IHealthEmployStatusRepo _dbStatus;

        public HealthEmployStatusController(IHealthEmployStatusRepo context)
        {
            _dbStatus = context;
        }

        [HttpGet]
        public async Task<IEnumerable<HealthEmployStatus>> ListAsync()
        {
            return await _dbStatus.ListAsync();
        }

        [HttpGet("{idStatus}")]
        public async Task<HealthEmployStatus> FindByIdAsync(int? idStatus)
        {
            HealthEmployStatus? _status = new HealthEmployStatus();
            if (idStatus != null)
            {
                _status = await _dbStatus.FindByIdAsync(idStatus);
            }
            return _status;
        }

    }
}
