using System.ComponentModel.DataAnnotations;

namespace HealthControlApp.API.Models.DomainModels
{
    public class HealthEmployStatusRepo
    {
        public int Id { get; set; }
        [Required]
        public string textHealthStatus { get; set; }// Description

    }

    // Healthy, Sick, Unknown

}
