using Moq;
using TestingApp.Functionality;
using TestingApp.Models;
using Xunit;

namespace TestingApp.Test
{
    public class ShoppingCartTest
    {
        public readonly Mock<IDbService> _dbService = new();

        [Fact]
        public void Add_product()
        {
            var dbService = new DbService();
            dbService.ProcessResult = true;
            var shoppingcart = new ShoppingCart(dbService);

            var product = new Product(1, "shoe", 120);
            var result = shoppingcart.AddProduct(product);

            Assert.True(result);
            Assert.Equal(result, dbService.ProcessResult);
            Assert.Equal("shoe", dbService.ProductBeingProcessed.Name);
        }

        [Fact]
        public void Add_product_failed_when_invalid_payload()
        {
            var dbService = new DbService();
            dbService.ProcessResult = false;
            var shoppingcart = new ShoppingCart(dbService);

            var result = shoppingcart.AddProduct(null);

            Assert.False(result);
            Assert.Equal(result, dbService.ProcessResult);
        }

        [Fact]
        public void Remove_product_success()
        {
            var dbService = new DbService();
            dbService.ProcessResult = true;
            var shoppingcart = new ShoppingCart(dbService);

            var product = new Product(1, "shoe", 120);
            var result = shoppingcart.AddProduct(product);

            var deleteResult = shoppingcart.DeleteProduct(product.Id);

            Assert.True(deleteResult);
            Assert.Equal(deleteResult, dbService.ProcessResult);
        }
    }
}
