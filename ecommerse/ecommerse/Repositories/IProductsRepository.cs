using System;
using System.Collections.Generic;
using ecommerse.Models;

namespace ecommerse.Repositories
{
    public interface IProductsRepository
    {
       List<Products> Get();
       Products Get(int id);
       bool Add(Products products);
       void Delete(int id);
    }
}
