using EShop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace testapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CreditCardController : ControllerBase
{
    protected ICardService _cardService;
    public CreditCardController(ICardService cardService)
    {
        _cardService = cardService;
    }

    [HttpGet]
    public IActionResult Get(string cardNumber)
    {
        try{
            _cardService.ValidateCard(cardNumber);
            return Ok();
        }
    }
}
