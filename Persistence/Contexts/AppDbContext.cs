using HealthControlApp.API.Models.MainModels;
using Microsoft.EntityFrameworkCore;

namespace HealthControlApp.API.Persistence.Contexts
{

    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("HealthControlApp.API"));
        }

        public DbSet<Employ> Employ { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<HealthEmployStatus> HealthEmployStatuses { get; set; }
        public DbSet<MainGroup> MainGroups { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
