using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using ecommerse.Models;
using MySql.Data.MySqlClient;

namespace ecommerse.Repositories
{
    public class CartitemRepository
    {
        private readonly string connectionString;

        public CartitemRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Cartitem> Get()
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                return connection.Query<Cartitem>("SELECT * FROM Cartitems").ToList();

            }
        }

        public List<Cartitem> Get(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                return connection.Query<Cartitem>("SELECT * FROM Cartitems WHERE cart_id = @id", new { id }).ToList();

            }
        }

        public bool Add(Cartitem cartitem)
        {
            if (true)
            {
                using (var connection = new MySqlConnection(this.connectionString))
                {
                    connection.Execute("INSERT INTO Cartitems (cart_id, product_id) VALUES(@cart_id, @product_id)", cartitem);
                }
            }
            return false;
        }

        public void Delete(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("DELETE FROM Cartitems WHERE Id = @id", new { id });
            }
        }
    }
}

