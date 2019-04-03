using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using ecommerse.Models;
using MySql.Data.MySqlClient;

namespace ecommerse.Repositories
{
    public class CartsRepository
    {
        private readonly string connectionString;

        public CartsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // get cart and cartitems
        public Carts GetCart(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var cart = connection.QuerySingleOrDefault<Carts>("SELECT * FROM Carts WHERE id = @id", new { id });
                if (cart == null)
                {
                    return null;
                }
                cart.Products = connection.Query<Products>("SELECT * FROM Cartitems INNER JOIN Products ON Cartitems.product_id = Products.Id WHERE Cartitems.cart_id = @id", new { id }).ToList();
                return cart;
            }
        }

        //public List<Cartitem> Get(int id)
        //{
        //    using (var connection = new MySqlConnection(this.connectionString))
        //    {
        //        return connection.Query<Cartitem>("SELECT * FROM Cartitems WHERE cart_id = @id", new { id }).ToList();

        //    }
        //}

        // add to cart
        public bool Add(Cartitem cartitem)
        {
            if (true)
            {
                using (var connection = new MySqlConnection(this.connectionString))
                {
                    connection.Execute("INSERT INTO Cartitems (cart_id, product_id) VALUES (@cart_id, @product_id)", cartitem);
                }
            }
            return false;
        }

        // Delete the hole cart
        public void DeleteCart(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("DELETE FROM Cartitems WHERE cart_id = @id", new { id });                 connection.Execute("DELETE FROM Carts WHERE id = @id", new { id });
            }
        }

        public void CreateCart(Cartitem cartitem)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO Carts (Id) VALUES (@cart_id)", cartitem);
            }
        }
    }
}


