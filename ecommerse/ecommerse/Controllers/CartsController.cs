using System.Collections.Generic;
using ecommerse.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ecommerse.Services;
using ecommerse.Repositories;

namespace ecommerse.Controllers
{
    [Route("api/[controller]")]
    public class CartsController : Controller
    {
        private readonly string connectionString;
        private readonly CartsService cartsService;
        public CartsController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            this.cartsService = new CartsService(new CartsRepository(connectionString));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<Products>), StatusCodes.Status200OK)]
        public IActionResult GetCart(int id)
        {
            var cartsItem = this.cartsService.GetCart(id);
            if (cartsItem == null)
            {
                return NotFound();
            }
            return Ok(cartsItem);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]Cartitem cartitem)
        {
            var result = this.cartsService.Add(cartitem);

            if (!result)
            {
                return BadRequest();
            }

            var cartResults = this.cartsService.GetCart(cartitem.cart_id);
            if (cartResults == null)
            {
                this.cartsService.CreateCart(cartitem);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Carts), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void Delete(int id)
        {
            this.cartsService.DeleteCart(id);
        }

    }

}


