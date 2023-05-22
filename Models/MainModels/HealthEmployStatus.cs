using System.ComponentModel.DataAnnotations;

namespace HealthControlApp.API.Models.MainModels
{
    public class HealthEmployStatus
    {
        public int Id { get; set; }
        [Required]
        public string textHealthStatus { get; set; } // Description
    }

}
