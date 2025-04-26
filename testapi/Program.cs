using EShop.Application.Services;
using EShop.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using EShop.Domain.Seeders;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("TestDb"), ServiceLifetime.Transient);

// Add services to the container.
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<IEShopSeeder, EShopSeeder>();

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

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IEShopSeeder>();
await seeder.Seed();

app.Run();
