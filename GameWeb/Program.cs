using GameWeb.Context;
using GameWeb.Repositories;
using GameWeb.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ConnectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<FarmDbContext>(options => options.UseSqlServer(ConnectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
               policy => {
                   policy.AllowAnyOrigin();
                   policy.AllowAnyHeader();
               });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Repositories
builder.Services.AddScoped<ITypeEnergyRepository, TypeEnergyRepository>();
builder.Services.AddScoped<IFarmsRepository, FarmsRepository>();
builder.Services.AddScoped<IDevicesTypeEnergyRepository, DevicesTypeEnergyRepository>();
builder.Services.AddScoped<IDevicesRepository, DevicesRepository>();
builder.Services.AddScoped<ITasksRepository, TasksRepository>();
builder.Services.AddScoped<ICropsRepository, CropsRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
#endregion


#region Services
builder.Services.AddScoped<ITypeEnergyService, TypeEnergyService>();
builder.Services.AddScoped<IFarmsService, FarmsService>();
builder.Services.AddScoped<IDevicesTypeEnergyService, DevicesTypeEnergyService>();
builder.Services.AddScoped<IDevicesService, DevicesService>();
builder.Services.AddScoped<ITasksService, TasksService>();
builder.Services.AddScoped<ICropsService, CropsService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGameService, GameService>();
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


