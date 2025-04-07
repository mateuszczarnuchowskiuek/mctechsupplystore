using System;

namespace EShop.Domain;

public class CardNumberTooShortException : Exception
{
    public CardNumberTooShortException() { }
    public CardNumberTooShortException() : base("Card number is too short!") { }
    public CardNumberTooShortException(Exception innerException) : base("Card number is too short", innerException) { }
}
