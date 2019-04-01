using System;
using System.Collections.Generic;
using ecommerse.Models;
using ecommerse.Repositories;

namespace ecommerse.Services
{
    public class OrdersService
    {
        private readonly OrdersRepository ordersRepository;

        public OrdersService(OrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public List<Orders> Get()
        {
            return this.ordersRepository.Get();
        }

        public Orders Get(int id)
        {
            return this.ordersRepository.Get(id);
        }

        public bool Add(Orders orders, Carts carts)
        {
            if (string.IsNullOrEmpty(orders.Firstname))
            {
                return false;
            }
            if (string.IsNullOrEmpty(orders.Lastname))
            {
                return false;
            }
            if (string.IsNullOrEmpty(orders.Adress))
            {
                return false;
            }
            if (orders.Zipcode <= 0)
            {
                return false;
            }
            if (string.IsNullOrEmpty(orders.City))
            {
                return false;
            }
            if (orders.cart_id <= 0)
            {
                return false;
            }

            this.ordersRepository.Add(orders, carts);
            return true;
        }

        public void Delete(int id)
        {
            this.ordersRepository.Delete(id);
        }
    }
}


