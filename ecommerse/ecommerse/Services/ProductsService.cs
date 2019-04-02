using System;
using System.Collections.Generic;
using ecommerse.Models;
using ecommerse.Repositories;

namespace ecommerse.Services
{
    public class ProductsService
    {
        private readonly IProductsRepository productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public List<Products> Get()
        {
            return this.productsRepository.Get();
        }

        public Products Get(int id)
        {
            return this.productsRepository.Get(id);
        }

        public bool Add(Products products)
        {
            if (string.IsNullOrEmpty(products.Product))
            {
                return false;
            }
            if (string.IsNullOrEmpty(products.Description))
            {
                return false;
            }
            if (products.Price <= 0)
            {
                return false;
            }
            if (string.IsNullOrEmpty(products.Image))
            {
                return false;
            }
            this.productsRepository.Add(products);
            return true;
        }

        public void Delete(int id)
        {
            this.productsRepository.Delete(id);
        }
    }
}
