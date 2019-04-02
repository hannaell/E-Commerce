using ecommerse.Repositories;
using ecommerse.Services;
using ecommerse.Models;
using NUnit.Framework;
using FakeItEasy;
using System.Collections.Generic;
using System.Linq;

namespace ecommerse.UnitTests.Services
{
    public class ProductsSerivceTest
    {
        private IProductsRepository productsRepository;
        private ProductsService productsService;


        [SetUp] 
        public void SetUp()
        {
            this.productsRepository = A.Fake<IProductsRepository>();
            this.productsService = new ProductsService(this.productsRepository);
        }

        [Test]
        public void Get_ReturnsResultFromRepository()
        {
            // Arrange
            var productItem = new Products
            {
                Id = 13,
                Product = "Green Melon",
                Description = "A green melon",
                Price = 10,
                Image = "https://media.mercola.com/assets/images/foodfacts/honeydew.jpg"
            };

            var productItems = new List<Products>
            {
                productItem
            };

            A.CallTo(() => this.productsRepository.Get()).Returns(productItems);

            // Act
            var result = this.productsService.Get().Single();

            // Assert
            Assert.That(result, Is.EqualTo(productItem));
        }

        [Test]
        public void Get_GivenId_ReturnsResultFromRepository()
        {
            // Arrange
            var Id = 13;
            var productItem = new Products
            {
                Id = Id,
                Product = "Green Melon",
                Description = "A green melon",
                Price = 10,
                Image = "https://media.mercola.com/assets/images/foodfacts/honeydew.jpg"
            };

            A.CallTo(() => this.productsRepository.Get(Id)).Returns(productItem);

            // Act
            var result = this.productsService.Get(Id);

            // Assert
            Assert.That(result, Is.EqualTo(productItem));
        }
    }
}
