using System.ComponentModel.DataAnnotations;

namespace HealthControlApp.API.Models.DomainModels
{
    public class GroupRepo
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public MainGroupRepo MainGroup { get; set; }
    }

}