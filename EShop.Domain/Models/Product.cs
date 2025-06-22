using System.ComponentModel;
using System.ComponentModel.DataAnnotations;    //needed for these decorators to work
using System.ComponentModel.DataAnnotations.Schema; //needed for these decorators to work

namespace EShop.Domain.Models
{
    public class Product : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Ean { get; set; } = string.Empty;
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public int Stock { get; set; } = 0;
        public string Sku { get; set; } = string.Empty;
        public Category Category { get; set; }
    }
}
