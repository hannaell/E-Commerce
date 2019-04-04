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
    public class OrdersController : Controller
    {
        private readonly string connectionString;
        private readonly OrdersService ordersService;
        public OrdersController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            this.ordersService = new OrdersService(new OrdersRepository(connectionString), new OrderitemsRepository(connectionString), new ProductsRepository(connectionString), new CartitemRepository(connectionString));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Orders>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var ordersItem = this.ordersService.Get();
            if (ordersItem == null)
            {
                return NotFound();
            }
            return Ok(ordersItem);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Products), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var ordersItem = this.ordersService.Get(id);
            if (ordersItem == null)
            {
                return NotFound();
            }
            return Ok(ordersItem);
        }

        // api/orders/2   POST , Takes order customer info from Order orders and puts cartitems in cart 2 to orderitems
        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(int id, [FromBody]Orders orders)
        {
            var result = this.ordersService.Add(id, orders);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Orders), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void Delete(int id)
        {
            this.ordersService.Delete(id);
        }

    }

}

