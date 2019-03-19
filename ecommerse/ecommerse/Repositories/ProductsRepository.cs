using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using ecommerse.Models;
using MySql.Data.MySqlClient;

namespace ecommerse.Repositories
{
    public class ProductsRepository
    {
        private readonly string connectionString;

        public ProductsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Products> Get()
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                return connection.Query<Products>("SELECT * FROM Products").ToList();

            }
        }

        public Products Get(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                return connection.QuerySingleOrDefault<Products>("SELECT * FROM News WHERE Id = @id", new { id });

            }
        }

        public bool Add(Products products)
        {
            if (true)
            {
                using (var connection = new MySqlConnection(this.connectionString))
                {
                    connection.Execute("INSERT INTO Products (Product, Description, Price, Quantity) VALUES(@product, @description, @price, @quantity)", products);
                }
            }
            return false;
        }

        public void Delete(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("DELETE FROM Products WHERE Id = @id", new { id });
            }
        }
    }
}
