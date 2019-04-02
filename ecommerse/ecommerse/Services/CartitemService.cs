using System;
using System.Collections.Generic;
using ecommerse.Models;
using ecommerse.Repositories;

namespace ecommerse.Services
{
    public class CartitemService
    {
        private readonly CartitemRepository cartitemRepository;

        public CartitemService(CartitemRepository cartitemRepository)
        {
            this.cartitemRepository = cartitemRepository;
        }

        public List<Cartitem> Get()
        {
            return this.cartitemRepository.Get();
        }

        public List<Cartitem> Get(int id)
        {
            return this.cartitemRepository.Get(id);
        }

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
            this.cartitemRepository.Add(cartitem);
            return true;
        }

        public void Delete(int id)
        {
            this.cartitemRepository.Delete(id);
        }
    }
}

