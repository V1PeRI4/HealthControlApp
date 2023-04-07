using Microsoft.Build.Framework;

namespace HealthControlApp.API.Models.DomainModels
{

    public class UserRepo
    {
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Pass { get; set; }
        public GroupRepo Group { get; set; }
        public RoleRepo Role { get; set; }
        public EmployRepo Employ { get; set; }
        public bool IsDeleted { get; set; }
    }

}