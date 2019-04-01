using System;
using System.Linq;
using System.Transactions;
using ecommerse.Models;
using ecommerse.Repositories;
using ecommerse.Services;
using NUnit.Framework;

namespace ecommerse.IntegrationTests.Services
{
    public class ProductsServiceTests
    {
        private ProductsService productsService;

        [SetUp]
        public void SetUp()
        {
            this.productsService = new ProductsService(new ProductsRepository(
                "Server=localhost;Port=8889;Database=ecommerce;Uid=root;Pwd=root;"));
        }

        [Test]
        public void Get_ReturnsResultsFromDatabase()
        {
            // Act
            var results = this.productsService.Get();

            // Assert
            Assert.That(results.Count, Is.AtLeast(3));
            Assert.That(results[0].Id, Is.EqualTo(6));
            Assert.That(results[0].Product, Is.EqualTo("honeydew melon"));
            Assert.That(results[0].Price, Is.EqualTo(50));
        }

        [Test]
        public void Get_GivenId_ReturnsResultFromDatabase()
        {
            // Arrange
            const string ExpectedName = "watermelon";
            const string ExpectedDescription = "A melon with a green outside and a red inside";
            const int ExpectedPrice = 30;
            const string ExpectedImage = "https://images-na.ssl-images-amazon.com/images/I/812c9h8-zuL._SY355_.jpg";
            const int Id = 9;

            // Act
            var results = this.productsService.Get(Id);

            // Assert
            Assert.That(results.Product, Is.EqualTo(ExpectedName));
            Assert.That(results.Description, Is.EqualTo(ExpectedDescription));
            Assert.That(results.Price, Is.EqualTo(ExpectedPrice));
            Assert.That(results.Image, Is.EqualTo(ExpectedImage));
        }

        [Test]
        public void Add_GivenValidProduct_SavesIt()
        {
            // Arrange
            const string ExpectedName = "Cantaloupe melon";
            const string ExpectedDescription = "A greenish melon with a orange inside";
            const int ExpectedPrice = 100;
            const string ExpectedImage = "https://cdn.shopify.com/s/files/1/1143/3886/products/cantaloupe_8e1fe76a-8331-4b3d-844e-2bfb549075cc_1024x1024.jpg?v=1522431966";

            var products = new Products
            {
                Product = ExpectedName,
                Description = ExpectedDescription,
                Price = ExpectedPrice,
                Image = ExpectedImage
            };


            bool results;

            // Act
            using (new TransactionScope())
            {
                results = this.productsService.Add(products);

            }

            // Assert
            Assert.That(results, Is.EqualTo(true));

        }

        [Test]
        public void Add_GivenValidProduct_DeletesIt()
        {
            // Arrange
            const string ExpectedName = "Cantaloupe melon";
            const string ExpectedDescription = "A greenish melon with a orange inside";
            const int ExpectedPrice = 100;
            const string ExpectedImage = "https://cdn.shopify.com/s/files/1/1143/3886/products/cantaloupe_8e1fe76a-8331-4b3d-844e-2bfb549075cc_1024x1024.jpg?v=1522431966";

            var products = new Products
            {
                Product = ExpectedName,
                Description = ExpectedDescription,
                Price = ExpectedPrice,
                Image = ExpectedImage
            };


            Products results;

            // Act
            using (new TransactionScope())
            {
                this.productsService.Add(products);
                results = this.productsService.Get().Last();
                this.productsService.Delete(results.Id);
                results = this.productsService.Get(results.Id);
            }

            // Assert
            Assert.That(results, Is.EqualTo(null));

        }
    }
}
