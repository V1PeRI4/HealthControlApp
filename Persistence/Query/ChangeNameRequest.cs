namespace HealthControlApp.API.Persistence.Query
{
    public class ChangeNameRequest
    {
        public int id { get; set; }
        public string newName{ get; set; } = null!;
    }
}
