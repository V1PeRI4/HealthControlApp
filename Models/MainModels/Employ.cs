using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;

namespace HealthControlApp.API.Models.MainModels
{
    public class Employ
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public int IdGroup { get; set; }
        public int IdHealthEmployStatus { get; set; }

    }
}