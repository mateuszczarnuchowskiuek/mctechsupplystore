using EShop.Application.Services;
using Microsoft.AspNetCore.Mvc;
using EShop.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EShopService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }




        // GET: api/<ClientController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _clientService.GetAllAsync();
            if (result.Count == 0)
                return NotFound();

            return Ok(result);
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _clientService.GetAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /*
         * Methodes not needed for now
         * 
         * 
        // POST api/<ClientController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
