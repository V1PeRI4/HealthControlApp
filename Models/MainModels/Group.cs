using System.ComponentModel.DataAnnotations;

namespace HealthControlApp.API.Models.MainModels

{
    public class Group
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int IdMainGroup { get; set; }


    }

}
