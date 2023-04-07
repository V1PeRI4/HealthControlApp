using Microsoft.Build.Framework;

namespace HealthControlApp.API.Models.MainModels
{

    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Pass { get; set; }
        public int IdGroup { get; set; }
        public int IdRole { get; set; }
        public int IdEmploy { get; set; }
        public bool IsDeleted { get; set; }
    }

}