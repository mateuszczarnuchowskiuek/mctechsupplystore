namespace EShop.Domain.Models;

public class Category : BaseModel
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
}
