using System;

namespace EShop.Domain;

public class CardNumberTooLongException : Exception
{
    private const string MessageContent = "Card number is too long!";
    public CardNumberTooLongException() : base(MessageContent) { }
    public CardNumberTooLongException(Exception innerException) : base(MessageContent, innerException) { }
}
