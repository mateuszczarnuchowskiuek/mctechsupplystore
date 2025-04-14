using System;

namespace EShop.Domain;

public class CardNumberTooShortException : Exception
{
    private const string MessageContent = "Card number is too short!";
    public CardNumberTooShortException() : base(MessageContent) { }
    public CardNumberTooShortException(Exception innerException) : base(MessageContent, innerException) { }
}
