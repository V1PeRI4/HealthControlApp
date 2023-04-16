using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthControlApp.API.Models.MainModels
{
    public class Employ
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FatherName { get; set; }
        [Required]
        public int IdGroup { get; set; }
        [Required]
        public int IdHealthEmployStatus { get; set; }

    }
}