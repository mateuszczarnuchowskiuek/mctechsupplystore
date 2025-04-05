using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Xunit;
using EShop.Application.Services;

namespace Eshop.Application.Tests.Services;

public class CardServiceTests
{
    [Fact]
    public void ValidateCard_CardNumberHas12Digits_ExpectedFalse()
    {
        string input = "12-345 67890  12";
        var service = new CardService();
        Assert.Equal(service.ValidateCard(input), false);
    }
    [Fact]
    public void ValidateCard_CardNumberHas20Digits_ExpectedFalse()
    {
        string input = "12-345 67890  1234567890";
        var service = new CardService();
        Assert.Equal(service.ValidateCard(input), false);
    }
    [Fact]
    public void ValidateCard_CardNumberHas13Digits_ExpectedTrue()
    {
        string input = "12-345 67890  123";
        var service = new CardService();
        Assert.Equal(service.ValidateCard(input), true);
    }
    [Fact]
    public void ValidateCard_CardNumberHas15Digits_ExpectedTrue()
    {
        string input = "12-345 67890  12345";
        var service = new CardService();
        Assert.Equal(service.ValidateCard(input), true);
    }
    [Fact]
    public void ValidateCard_CardNumberHas19Digits_ExpectedTrue()
    {
        string input = "12-345 67890  123456789";
        var service = new CardService();
        Assert.Equal(service.ValidateCard(input), true);
    }
    
    [Fact]
    public void ValidateCard_CardNumberHas15DigitsWithSpaces_ExpectedTrue()
    {
        string input = "  3497 7965  8312 797  ";
        var service = new CardService();
        Assert.Equal(service.ValidateCard(input), true);
    }
    [Fact]
    public void ValidateCard_CardNumberHas15DigitsWithDashes_ExpectedTrue()
    {
        string input = "--3497-7965--8312-797--";
        var service = new CardService();
        Assert.Equal(service.ValidateCard(input), true);
    }
    [Fact]
    public void ValidateCard_CardNumberHas15DigitsWithSpacesAndDashes_ExpectedTrue()
    {
        string input = "  3497-7965--  8312 797--";
        var service = new CardService();
        Assert.Equal(service.ValidateCard(input), true);
    }
    
}