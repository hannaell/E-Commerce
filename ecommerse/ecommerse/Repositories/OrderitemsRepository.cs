using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using ecommerse.Models;
using MySql.Data.MySqlClient;

namespace ecommerse.Repositories
{
    public class OrderitemsRepository
    {
        private readonly string connectionString;

        public OrderitemsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Orderitem> Get()
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                return connection.Query<Orderitem>("SELECT * FROM Orderitems").ToList();

            }
        }

        public void Add(Orderitem orderitem)
        {

            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO Orderitems (order_id, product_name, product_description, product_price) VALUES(@order_id, @product_name, @product_description, @product_price)", orderitem);
            }
        }
    }
}
