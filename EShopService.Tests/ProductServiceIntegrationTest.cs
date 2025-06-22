using EShop.Domain.Models;
using EShop.Domain.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System.Net;
using System.Net.Http.Json;
using System.Reflection;


namespace EShopService.IntegrationTests.Controllers;



    public class ProductControllerIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private WebApplicationFactory<Program> _factory;

        public ProductControllerIntegrationTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        // pobranie dotychczasowej konfiguracji bazy danych
                        var dbContextOptions = services
                            .SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<DataContext>));

                        //// usuniêcie dotychczasowej konfiguracji bazy danych
                        services.Remove(dbContextOptions);

                        // Stworzenie nowej bazy danych
                        services
                            .AddDbContext<DataContext>(options => options.UseInMemoryDatabase("MyDBForTest"));

                    });
                });

            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task Get_ReturnsAllProducts()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                // Pobranie kontekstu bazy danych
                var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();

                dbContext.Products.RemoveRange(dbContext.Products);

                // Stworzenie obiektu
                dbContext.Products.AddRange(
                    new Product { Name = "Cobi", Ean = "1234", Price = 245.04m, Stock = 5, Sku = "ABC123XYZ", Category = new Category { Name = "klocki" } },
                    new Product { Name = "Duplo", Ean = "431", Price = 21.36m, Stock = 53, Sku = "PROD-45678", Category = new Category { Name = "agd" } }
                );
                // Zapisanie obiektu
                await dbContext.SaveChangesAsync();
            }

            // Act
            var response = await _client.GetAsync("/api/product");

            // Assert
            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadFromJsonAsync<List<Product>>();
            Assert.Equal(2, products?.Count);
        }

    }










