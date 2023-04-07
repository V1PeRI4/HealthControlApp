using System.ComponentModel.DataAnnotations;

namespace HealthControlApp.API.Models.MainModels
{

    public class Role
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }

}