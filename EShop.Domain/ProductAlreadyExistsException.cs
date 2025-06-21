namespace EShop.Domain;

public class ProductAlreadyExistsException : Exception
{
    private const string MessageContent = "Product already exists!";
    public ProductAlreadyExistsException() : base(MessageContent) { }
    public ProductAlreadyExistsException(Exception innerException) : base(MessageContent, innerException) { }
}
