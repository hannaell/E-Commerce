using System;
using System.Collections.Generic;
using ecommerse.Models;
using ecommerse.Repositories;

namespace ecommerse.Services
{
    public class OrderitemsService
    {
        private readonly OrderitemsRepository orderitemsRepository;

        public OrderitemsService(OrderitemsRepository orderitemsRepository)
        {
            this.orderitemsRepository = orderitemsRepository;
        }

        public List<Orderitem> Get()
        {
            return this.orderitemsRepository.Get();
        }

        public bool Add(Orderitem orderitem)
        {
            this.orderitemsRepository.Add(orderitem);
            return true;
        }

    }
}

