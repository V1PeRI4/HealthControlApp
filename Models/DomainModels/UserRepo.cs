using Microsoft.Build.Framework;

namespace HealthControlApp.API.Models.DomainModels
{

    public class UserRepo
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public GroupRepo Group { get; set; }
        public HealthEmployStatusRepo HealthEmployStatus { get; set; }
        public RoleRepo Role { get; set; }
        public bool IsDeleted { get; set; }
    }

}