using System.ComponentModel;

namespace testapi.Models
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
