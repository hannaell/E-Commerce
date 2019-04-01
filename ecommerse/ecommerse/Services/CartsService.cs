using System;
using System.Collections.Generic;
using ecommerse.Models;
using ecommerse.Repositories;

namespace ecommerse.Services
{
    public class CartsService
    {
        private readonly CartsRepository cartsRepository;

        public CartsService(CartsRepository cartsRepository)
        {
            this.cartsRepository = cartsRepository;
        }

        public Carts GetCart(int id)
        {
            return this.cartsRepository.GetCart(id);
        }

        //public List<Cartitem> Get(int id)
        //{
        //    return this.cartsRepository.Get(id);
        //}

        public bool Add(Cartitem cartitem)
        {
            if (cartitem.product_id <= 0)
            {
                return false;
            }
            if (cartitem.cart_id <= 0)
            {
                return false;
            }
            this.cartsRepository.Add(cartitem);
            return true;
        }

        public void DeleteCart(int id)
        {
            this.cartsRepository.DeleteCart(id);
        }
    }
}


