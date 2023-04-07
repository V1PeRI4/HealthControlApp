using System.ComponentModel.DataAnnotations;

namespace HealthControlApp.API.Models.DomainModels
{
    public class HealthEmployStatusRepo
    {
        public int Id { get; set; }
        [Required]
        public HealthStatusRepo HealthStatus { get; set; }
        public string Description { get; set; }



        public HealthStatusRepo SetStatusRepo(int idStatus)
        {
            switch (idStatus)
            {
                case 0:
                    return HealthStatusRepo.Healthy;
                case 1:
                    return HealthStatusRepo.Sick;
                case 2:
                    return HealthStatusRepo.Unknown;
                default:
                    return HealthStatusRepo.Unknown;
            }
        }


    }


}
