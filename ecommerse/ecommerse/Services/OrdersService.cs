using System;
using System.Collections.Generic;
using System.Linq;
using ecommerse.Models;
using ecommerse.Repositories;

namespace ecommerse.Services
{
    public class OrdersService
    {
        private readonly OrdersRepository ordersRepository;
        private readonly OrderitemsRepository orderitemsRepository;
        private readonly IProductsRepository productsRepository;
        private readonly CartitemRepository cartitemRepository;

        public OrdersService(OrdersRepository ordersRepository, OrderitemsRepository orderitemsRepository, IProductsRepository productsRepository, CartitemRepository cartitemRepository)
        {
            this.ordersRepository = ordersRepository;
            this.orderitemsRepository = orderitemsRepository;
            this.productsRepository = productsRepository;
            this.cartitemRepository = cartitemRepository;
        }

        public List<Orders> Get()
        {
            return this.ordersRepository.Get();
        }

        public Orders Get(int id)
        {
            return this.ordersRepository.Get(id);
        }

        public bool Add(int cart_id, Orders orders)
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

            var orderId = this.ordersRepository.Add(orders);

            var cartItems = this.cartitemRepository.Get(orderId);

            var orderItems = cartItems.Select(cartItem =>
            {
                var productItem = this.productsRepository.Get(cartItem.product_id);

                return new Orderitem
                {
                    order_id = orderId,
                    product_name = productItem.Product,
                    product_description = productItem.Description,
                    product_price = productItem.Price
                };

            }).ToList();

            orderItems.ForEach(orderItem =>
            {
                this.orderitemsRepository.Add(orderItem);
            });


            return true;
        }

        public void Delete(int id)
        {
            this.ordersRepository.Delete(id);
        }
    }
}


