using HealthControlApp.API.Models.MainModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HealthControlApp.API.Persistence.QueryResults;

namespace HealthControlApp.API.Persistence.Contexts
{

    public class AppDbContext : IdentityUserContext<IdentityUser>
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
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
        public DbSet<RegistrationRequest> RegistrationRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RegistrationRequest>().HasNoKey();
        }
    }
}
