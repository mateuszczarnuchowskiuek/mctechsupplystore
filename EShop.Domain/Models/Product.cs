using System.ComponentModel;
using System.ComponentModel.DataAnnotations;    //needed for these decorators to work
using System.ComponentModel.DataAnnotations.Schema; //needed for these decorators to work

namespace EShop.Domain.Models
{
    public class Product : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string ean { get; set; } = string.Empty;
        [Column(TypeName = "decimal(10,2)")]
        public decimal price { get; set; }
        public int stock { get; set; } = 0;
        public string sku { get; set; } = string.Empty;
        public Category category { get; set; } = default!;
    }
}
