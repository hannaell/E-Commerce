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
    public class ProductsController : Controller
    {
        private readonly string connectionString;
        private readonly ProductsService productsService;
        public ProductsController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            this.productsService = new ProductsService(new ProductsRepository(connectionString));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Products>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var productItem = this.productsService.Get();
            if (productItem == null)
            {
                return NotFound();
            }
            return Ok(productItem);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Products), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var productItem = this.productsService.Get(id);
            if (productItem == null)
            {
                return NotFound();
            }
            return Ok(productItem);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]Products products)
        {
            var result = this.productsService.Add(products);

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
            this.productsService.Delete(id);
        }

    }

}
