using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Xunit;
using EShop.Application.Services;
using EShop.Domain;

namespace Eshop.Application.Tests.Services;

public class CardServiceTests
{
    [Fact]
    public void ValidateCard_CardNumberHas12Digits_ExpectedCardNumberTooShortException()
    {
        string input = "230914554590";
        var service = new CardService();
        Assert.Throws<CardNumberTooShortException>(() => service.ValidateCard(input));
    }
    [Fact]
    public void ValidateCard_CardNumberHas20Digits_ExpectedCardNumberTooLongException()
    {
        string input = "26081981298536520573";
        var service = new CardService();
        Assert.Throws<CardNumberTooLongException>(() => service.ValidateCard(input));
    }
    [Fact]
    public void ValidateCard_CardNumberHas13Digits_ExpectedTrue()
    {
        string input = "0091745169226";
        var service = new CardService();
        Assert.True(service.ValidateCard(input));
    }
    [Fact]
    public void ValidateCard_CardNumberHas15Digits_ExpectedTrue()
    {
        string input = "841772999127548";
        var service = new CardService();
        Assert.True(service.ValidateCard(input));
    }
    [Fact]
    public void ValidateCard_CardNumberHas19Digits_ExpectedTrue()
    {
        string input = "5252074388656952720";
        var service = new CardService();
        Assert.True(service.ValidateCard(input));
    }
    [Fact]
    public void ValidateCard_CardNumberHas15DigitsWithSpaces_ExpectedTrue()
    {
        string input = "  60260 219  49090  86  ";
        var service = new CardService();
        Assert.True(service.ValidateCard(input));
    }
    [Fact]
    public void ValidateCard_CardNumberHas15DigitsWithDashes_ExpectedTrue()
    {
        string input = "--6026-0219--4909086---";
        var service = new CardService();
        Assert.True(service.ValidateCard(input));
    }
    [Fact]
    public void ValidateCard_CardNumberHas15DigitsWithSpacesAndDashes_ExpectedTrue()
    {
        string input = "  602  6021 949-090--86--";
        var service = new CardService();
        Assert.True(service.ValidateCard(input));
    }
    [Fact]
    public void ValidateCard_CardNumberContainsInvalidCharacters_ExpectedCardNumberInvalidException()
    {
        string input = "v4344Oh4397938910p";
        var service = new CardService();
        Assert.Throws<CardNumberInvalidException>(() => service.ValidateCard(input));
    }
    [Theory]
    [InlineData("3497 7965 8312 797")]
    [InlineData("345-470-784-783-010")]
    [InlineData("378523393817437")]
    [InlineData("4024-0071-6540-1778")]
    [InlineData("4532 2080 2150 4434")]
    [InlineData("4532289052809181")]
    [InlineData("5530016454538418")]
    [InlineData("5551561443896215")]
    [InlineData("5131208517986691")]
    public void ValidateCard_ValidCardNumber_ExpectedTrue(string input)
    {
        var service = new CardService();
        Assert.True(service.ValidateCard(input));
    }

    [Theory]
    [InlineData("3497 7965 8312 797", "American Express")]
    [InlineData("345-470-784-783-010", "American Express")]
    [InlineData("378523393817437", "American Express")]
    [InlineData("4024-0071-6540-1778", "Visa")]
    [InlineData("4532 2080 2150 4434", "Visa")]
    [InlineData("4532289052809181", "Visa")]
    [InlineData("5530016454538418", "MasterCard")]
    [InlineData("5551561443896215", "MasterCard")]
    [InlineData("5131208517986691", "MasterCard")]
    public void GetCardType_ValidCardNumber_ExpectedReturnCorrectProvider(string input, string expected)
    {
        var service = new CardService();
        Assert.Equal(expected, service.GetCardType(input));
    }
}