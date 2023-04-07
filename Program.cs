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

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql("Host=127.0.0.1; Port=5432; Database=HealthControl; Username=postgres; Password=admin"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*  DI  */
builder.Services.AddScoped<IEmployRepo, EmploysRepository>();
builder.Services.AddScoped<IGroupRepo,GropuRepository>();
builder.Services.AddScoped<IHealthEmployStatusRepo, HealthEmployStatusRepository>();
builder.Services.AddScoped<IMainGroupRepo, MainGroupRepository>();
builder.Services.AddScoped<IRoleRepo, RoleRepository>();
builder.Services.AddScoped<IUserRepo, UserRepository>();

builder.Services.AddScoped<IEmployServices, EmployServices>();
builder.Services.AddScoped<IGroupServices, GroupServices>();
builder.Services.AddScoped<IUserServices, UserServices>();



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

app.UseAuthorization();

app.MapControllers();

app.Run();
