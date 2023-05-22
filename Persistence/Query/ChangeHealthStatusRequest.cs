namespace HealthControlApp.API.Persistence.Query
{
    public class ChangeHealthStatusRequest
    {
        public int id { get; set; }
        public int idNewStatus { get; set; }
    }
}
