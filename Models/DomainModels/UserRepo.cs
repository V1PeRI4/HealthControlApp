using Microsoft.Build.Framework;

namespace HealthControlApp.API.Models.DomainModels
{

    public class UserRepo
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        public RoleRepo Role { get; set; }
        public EmployRepo Employ { get; set; }
        public bool IsDeleted { get; set; }
    }

}