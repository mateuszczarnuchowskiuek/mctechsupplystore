using EShop.Application.Services;
using EShop.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using EShop.Domain.Seeders;
using Google.Protobuf.WellKnownTypes;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddScoped<ICardService, CardService>();
        builder.Services.AddScoped<IRepository, Repository>();
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IClientService, ClientService>();
        builder.Services.AddScoped<IEShopSeeder, EShopSeeder>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<ICartService, CartService>();


        builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("TestDb"), ServiceLifetime.Transient);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer(); // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddSwaggerGen();


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

        //Seeding data 
        var scope = app.Services.CreateScope();
        var seeder = scope.ServiceProvider.GetRequiredService<IEShopSeeder>();
        await seeder.SeedCategory();
        await seeder.SeedCart();
        await seeder.SeedProducts();
        await seeder.SeedClients();


        app.Run();
    }
}