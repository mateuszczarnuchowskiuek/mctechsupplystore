using System;

namespace EShop.Domain;

public class CardNumberInvalidException : Exception
{
    public CardNumberInvalidException() { }
    public CardNumberInvalidException() : base("Card number is invalid!") { }
    public CardNumberTooLongException(Exception innerException) : base("Card number is too long", innerException) { }
}
