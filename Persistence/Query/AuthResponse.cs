namespace HealthControlApp.API.Persistence.QueryResults
{
    public class AuthResponse
    {
        public int Id { get; set; }
        public string username { get; set; } = null!;
        public string email { get; set; } = null!;
        public int role { get; set; }
        public string token { get; set; } = null!;
    }
}
