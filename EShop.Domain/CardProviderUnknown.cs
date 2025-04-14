namespace EShop.Domain;

public class CardProviderUnknown : Exception
{
    private const string MessageContent = "Card provider unknown!";
    public CardProviderUnknown() : base(MessageContent) { }
    public CardProviderUnknown(Exception innerException) : base(MessageContent, innerException) { }
}
