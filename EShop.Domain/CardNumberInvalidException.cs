using System;

namespace EShop.Domain;

public class CardNumberInvalidException : Exception
{
    private const string MessageContent = "Card number is invalid!";
    public CardNumberInvalidException() : base(MessageContent) { }
    public CardNumberInvalidException(Exception innerException) : base(MessageContent, innerException) { }
}
