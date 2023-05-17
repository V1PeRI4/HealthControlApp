using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace HealthControlApp.API.Models.MainModels
{

    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FatherName { get; set; }
        [Required]
        public int IdGroup { get; set; }
        [Required]
        public int IdHealthStatus { get; set; }
        [Required]
        public int IdRole { get; set; }
        public bool IsDeleted { get; set; }
    }

}