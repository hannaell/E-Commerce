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
    public class Orderitemscontroller : Controller
    {
        private readonly string connectionString;
        private readonly OrderitemsService orderitemsService;
        public Orderitemscontroller(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            this.orderitemsService = new OrderitemsService(new OrderitemsRepository(connectionString));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Orderitem>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var orderitems = this.orderitemsService.Get();
            if (orderitems == null)
            {
                return NotFound();
            }
            return Ok(orderitems);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]Orderitem orderitem)
        {
            var result = this.orderitemsService.Add(orderitem);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }


    }

}

