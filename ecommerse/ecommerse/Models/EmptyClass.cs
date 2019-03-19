using System;
namespace ecommerse.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
