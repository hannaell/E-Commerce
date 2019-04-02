using System;
namespace ecommerse.Models
{
    public class Orderitem
    {
        public int id { get; set; }
        public int order_id { get; set; }
        public string product_name { get; set; }
        public string product_description { get; set; }
        public int product_price { get; set; }

    }
}
