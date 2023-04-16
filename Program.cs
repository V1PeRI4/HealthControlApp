using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HealthControlApp.API.Persistence.Contexts;
using HealthControlApp.API.Persistence.Repositories.EmployRepository;
using HealthControlApp.API.Persistence.Repositories.HealthEmployStatusRepository;
using HealthControlApp.API.Persistence.Repositories.GroupRepository;
using HealthControlApp.API.Persistence.Repositories.MainGroupRepository;
using HealthControlApp.API.Persistence.Repositories.RoleRepository;
using HealthControlApp.API.Persistence.Repositories.UserRepository;
using HealthControlApp.API.Persistence.Services.EmployServices;
using HealthControlApp.API.Persistence.Services.GroupServices;
using HealthControlApp.API.Persistence.Services.UserServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using HealthControlApp.API.Persistence.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql("Host=127.0.0.1; Port=5432; Database=HealthControl; Username=postgres; Password=admin"));

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        /* Authentication */
        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "apiWithAuthBackend",
                    ValidAudience = "apiWithAuthBackend",
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes("!SomethingSecret!")
                    ),
                };
            });


        builder.Services
            .AddIdentityCore<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<AppDbContext>();



        /*  DI  */
        builder.Services.AddScoped<IEmployRepo, EmploysRepository>();
        builder.Services.AddScoped<IGroupRepo, GropuRepository>();
        builder.Services.AddScoped<IHealthEmployStatusRepo, HealthEmployStatusRepository>();
        builder.Services.AddScoped<IMainGroupRepo, MainGroupRepository>();
        builder.Services.AddScoped<IRoleRepo, RoleRepository>();
        builder.Services.AddScoped<IUserRepo, UserRepository>();

        builder.Services.AddScoped<IEmployServices, EmployServices>();
        builder.Services.AddScoped<IGroupServices, GroupServices>();
        builder.Services.AddScoped<IUserServices, UserServices>();

        builder.Services.AddScoped<TokenService, TokenService>();




        /* AutoMapper */
        builder.Services.AddAutoMapper(typeof(Program));


       

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();


        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }

}