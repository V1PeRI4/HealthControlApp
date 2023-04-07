using System.ComponentModel.DataAnnotations;

namespace HealthControlApp.API.Models.MainModels

{
    public class Group
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdMainGroup { get; set; }


    }

}
