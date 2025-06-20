namespace EShop.Domain;

public class ProductNotFoundException : Exception
{
    private const string MessageContent = "Product not found!";
    public ProductNotFoundException() : base(MessageContent) { }
    public ProductNotFoundException(Exception innerException) : base(MessageContent, innerException) { }
}
