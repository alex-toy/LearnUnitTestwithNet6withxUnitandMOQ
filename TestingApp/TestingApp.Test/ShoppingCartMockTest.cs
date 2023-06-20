using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApp.Functionality;
using TestingApp.Models;
using Xunit;

namespace TestingApp.Test
{
    public class ShoppingCartMockTest
    {
        public readonly Mock<IDbService> _dbServiceMock = new();

        [Fact]
        public void Add_product()
        {
            var shoppingcart = new ShoppingCart(_dbServiceMock.Object);

            var product = new Product(1, "shoe", 120);
            var result = shoppingcart.AddProduct(product);

            Assert.True(result);
            _dbServiceMock.Verify(x => x.SaveItemToShoppingCart(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public void Add_product_failed_when_invalid_payload()
        {
            var shoppingcart = new ShoppingCart(_dbServiceMock.Object);

            var result = shoppingcart.AddProduct(null);

            Assert.False(result);
            _dbServiceMock.Verify(x => x.SaveItemToShoppingCart(It.IsAny<Product>()), Times.Never);
        }

        [Fact]
        public void Remove_product_success()
        {
            var shoppingcart = new ShoppingCart(_dbServiceMock.Object);

            var product = new Product(1, "shoe", 120);
            var result = shoppingcart.AddProduct(product);

            var deleteResult = shoppingcart.DeleteProduct(product.Id);

            Assert.True(deleteResult);
            _dbServiceMock.Verify(x => x.SaveItemToShoppingCart(It.IsAny<Product>()), Times.Once);
        }
    }
}
