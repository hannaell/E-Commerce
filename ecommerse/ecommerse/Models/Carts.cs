using System;
using System.Collections.Generic;

namespace ecommerse.Models
{
    public class Carts
    {
        public int id { get; set; }
        public List <Products> Products { get; set; }
    }
}
