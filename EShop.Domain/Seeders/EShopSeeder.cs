using EShop.Domain.Models;
using EShop.Domain.Repositories;

namespace EShop.Domain.Seeders;

public class EShopSeeder(DataContext context) : IEShopSeeder
{
    public async Task Seed()
    {
        var products = new List<Product>
        {
            new Product { name = "Electric Furnace", ean = "8315" },
            new Product { name = "Macerator", ean = "2908" },
            new Product { name = "Extractor", ean = "1308" }
        };

        context.Products.AddRange(products);
        context.SaveChanges();
    }
}
