    using System.ComponentModel.DataAnnotations;

namespace HealthControlApp.API.Models.DomainModels
{
    public class EmployRepo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public GroupRepo Group { get; set; }
        public HealthEmployStatusRepo HealthEmployStatus { get; set; }

    }
}