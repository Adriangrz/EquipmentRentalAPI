using EquipmentRental.Database;
using EquipmentRental.Database.Repositories;
using EquipmentRental.Database.Repositories.Interfaces;
using EquipmentRental.Services;
using EquipmentRental.Services.DatabaseService;
using EquipmentRental.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EquipmentRentalContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EquipmentRentalDatabase"));

});

builder.Services.AddScoped<IRentRepository, RentRepository>();
builder.Services.AddScoped<ISportEquipmentRepository, SportEquipmentRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IRentService, RentService>();
builder.Services.AddScoped<ISportEquipmentService, SportEquipmentService>();
builder.Services.AddScoped<IUserService, UserService>();

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
