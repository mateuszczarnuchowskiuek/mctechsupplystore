using EShop.Application.Services;
using EShop.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace testapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CreditCardController : ControllerBase
{
    protected ICardService cardServiceProvider;
    public CreditCardController(ICardService cardService)
    {
        cardServiceProvider = cardService;
    }

    [HttpGet]
    public IActionResult Get(string cardNumber)
    {
        try
        {
            cardServiceProvider.ValidateCard(cardNumber);
            return Ok(new { cardProvider = cardServiceProvider.GetCardType(cardNumber) });
        }
        catch (CardNumberTooShortException e)
        {
            return BadRequest(new { error = e.Message, code = HttpStatusCode.BadRequest });
        }
        catch (CardNumberTooLongException e)
        {
            return StatusCode((int)HttpStatusCode.RequestUriTooLong, new { error = e.Message, code = HttpStatusCode.RequestUriTooLong });
        }
        catch (CardNumberInvalidException e)
        {
            return BadRequest(new { error = e.Message, code = HttpStatusCode.BadRequest });
        }
        catch (CardProviderUnknown e)
        {
            return StatusCode((int)HttpStatusCode.NotAcceptable, new { error = e.Message, code = HttpStatusCode.NotAcceptable });
        }

    }
}
