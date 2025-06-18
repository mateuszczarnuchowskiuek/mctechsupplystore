using EShop.Domain.Repositories;
using EShop.Domain.Models;

namespace EShop.Domain.Seeders
{
    public class EShopSeeder(DataContext context) : IEShopSeeder
    {
        public async Task Seed()
        {
            if (!context.Products.Any())
            {
                var students = new List<Product>
                {
                    new Product { name = "Cobi", ean = "1234" },
                    new Product { name = "Duplo", ean = "431" },
                    new Product { name = "Lego", ean = "12212" }
                };

                context.Products.AddRange(students);
                context.SaveChanges();
            }
        }
    }
}
