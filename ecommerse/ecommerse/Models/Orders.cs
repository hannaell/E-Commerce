using System;
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
    }
}
