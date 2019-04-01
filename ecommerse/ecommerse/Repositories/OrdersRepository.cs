using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using ecommerse.Models;
using MySql.Data.MySqlClient;

namespace ecommerse.Repositories
{
    public class OrdersRepository
    {
        private readonly string connectionString;

        public OrdersRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Orders> Get()
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                return connection.Query<Orders>("SELECT * FROM Orders").ToList();

            }
        }

        public Orders Get(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                return connection.QuerySingleOrDefault<Orders>("SELECT * FROM Orders WHERE Id = @id", new { id });

            }
        }

        public int Add(Orders orders, Carts carts)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO Orders (Firstname, Lastname, Adress, Zipcode, City, cart_id) VALUES(@Firstname, @Lastname, @Adress, @Zipcode, @City, @cart_id)", orders); 
                var orderId = connection.QuerySingleOrDefault<int>("SELECT Id FROM Orders ORDER BY Id DESC LIMIT 1");
                return orderId;
            }  
        }

        public void Delete(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("DELETE FROM Orders WHERE Id = @id", new { id });
            }
        }
    }
}
