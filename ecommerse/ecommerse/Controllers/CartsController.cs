using System;
using System.Collections.Generic;
using ecommerse.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Dapper;
using System.Linq;
using MySql.Data.MySqlClient;
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

        //[HttpGet("{id}")]
        //[ProducesResponseType(typeof(List<Cartitem>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult Get(int id)
        //{
        //    var cartsItem = this.cartsService.Get(id);
        //    if (cartsItem == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(cartsItem);
        //}

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
            //using (var connection = new MySqlConnection(this.connectionString))
            //{
            //    connection.Execute("DELETE FROM News WHERE Id = @id", new { id });
            //}
            this.cartsService.DeleteCart(id);
        }

        //private static readonly List<Products> Database = new List<Products>
        //{
        //    new Products
        //    {
        //        Id = 1,
        //        Product = "Vans Old Skool",
        //        Description = "The original classic side stripe skate shoe. Built with Vans DNA.",
        //        Price = 500,
        //        Quantity = 5

        //    },

        //    new Products
        //    {
        //        Id = 2,
        //        Product = "Pearly Punk Old Skool Platform Shoes",
        //        Description = "The Pearly Punk Old Skool Platform combines the classic Vans sidestripe skate shoe with gentle suede uppers featuring metallic piping, custom embroidery, underlays, and pearl rivet eyelets.",
        //        Price = 700,
        //        Quantity = 6

        //    }
        //};
    }



}


