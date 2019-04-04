using System;
using System.Collections.Generic;

namespace ecommerse.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Adress { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }
        public List<Orderitem> Orderitems { get; set; }
    }
}
