using System.ComponentModel.DataAnnotations;

namespace HealthControlApp.API.Models.DomainModels
{

    public class MainGroupRepo
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }

}
