using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HealthControlApp.API.Persistence.QueryResults
{
    [Keyless]
    public class RegistrationRequest
    {

        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string FatherName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
