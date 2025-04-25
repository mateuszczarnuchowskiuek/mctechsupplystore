using System.ComponentModel;

namespace EShop.Domain.Models
{
    public class Product : BaseModel
    {
        public string ean;
        public decimal price;
        public int stock = 0;
        public string sku;
        public Category category;
    }
}
