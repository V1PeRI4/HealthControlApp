using System.ComponentModel.DataAnnotations;

namespace HealthControlApp.API.Models.DomainModels
{
    public class EmployRepo
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string SurName { get; set; }
        public HealthEmployStatusRepo HealthEmployStatus { get; set; }

    }
}