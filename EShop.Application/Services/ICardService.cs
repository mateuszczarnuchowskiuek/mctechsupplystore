namespace EShop.Application.Services;

public interface ICardService
{
    public bool ValidateCard(string cardNumber);
    public string GetCardType(string cardNumber);
}
