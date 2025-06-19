using System.ComponentModel;
using System.ComponentModel.DataAnnotations;    //potrzebne do tych dekoratorów
using System.ComponentModel.DataAnnotations.Schema; //potrzebne do tych dekoratorów

namespace EShop.Domain.Models
{
    public class Product : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string ean { get; set; } = string.Empty;
        public decimal price { get; set; }
        public int stock { get; set; } = 0;
        public string sku { get; set; } = string.Empty;
        public Category category { get; set; }
    }
}
