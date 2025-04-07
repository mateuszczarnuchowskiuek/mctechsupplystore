using System;

namespace EShop.Domain;

public class CardNumberTooLongException : Exception
{
    public CardNumberTooLongException() { }
    public CardNumberTooLongException() : base("Card number is too long!") { }
    public CardNumberTooLongException(Exception innerException) : base("Card number is too long", innerException) { }
}
