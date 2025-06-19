using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;    //potrzebne do tych dekoratorów
using System.ComponentModel.DataAnnotations.Schema; //potrzebne do tych dekoratorów
namespace EShop.Domain.Models;

public class Cart
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int id { get; set; }

    public Clients client { get; set; }

    public List<Product> products { get; set; }


}
