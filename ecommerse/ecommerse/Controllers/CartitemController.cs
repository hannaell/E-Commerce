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
    public class CartitemController : Controller
    {
        private readonly string connectionString;
        private readonly CartitemService cartitemService;
        public CartitemController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            this.cartitemService = new CartitemService(new CartitemRepository(connectionString));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Products>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var cartitemItem = this.cartitemService.Get();
            if (cartitemItem == null)
            {
                return NotFound();
            }
            return Ok(cartitemItem);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<Cartitem>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var cartitemItem = this.cartitemService.Get(id);
            if (cartitemItem == null)
            {
                return NotFound();
            }
            return Ok(cartitemItem);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]Cartitem cartitem)
        {
            var result = this.cartitemService.Add(cartitem);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Products), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void Delete(int id)
        {
            this.cartitemService.Delete(id);
        }

    }
   
}

