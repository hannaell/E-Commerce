﻿using System;
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
            //using (var connection = new MySqlConnection(this.connectionString))
            //{
            //    connection.Execute("DELETE FROM News WHERE Id = @id", new { id });
            //}
            this.productsService.Delete(id);
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
