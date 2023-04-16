using Microsoft.Build.Framework;

namespace HealthControlApp.API.Models.MainModels
{

    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Pass { get; set; }
        [Required]
        public int IdRole { get; set; }
        [Required]
        public int IdEmploy { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }

}