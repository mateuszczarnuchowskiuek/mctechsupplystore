using EShop.Domain.Repositories;
using EShop.Domain.Models;

namespace EShop.Domain.Seeders
{
    public class EShopSeeder(DataContext context) : IEShopSeeder
    {
        public async Task SeedProducts()
        {
            if (!context.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product { name = "Cobi", ean = "1234" },
                    new Product { name = "Duplo", ean = "431" },
                    new Product { name = "Lego", ean = "12212" }
                };

                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
        public async Task SeedClients()
        {
            if (!context.Clients.Any())
            {
                var clients = new List<Clients>
                {
                    new Clients { Name = "Mark" },
                    new Clients { Name = "Marry"},
                    new Clients { Name = "Leon" }
                };

                context.Clients.AddRange(clients);
                context.SaveChanges();
            }

        }
    }
}
