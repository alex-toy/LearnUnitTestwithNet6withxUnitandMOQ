using TestingApp.Functionality;
using TestingApp.Models;
using Xunit;

namespace TestingApp.Test
{
    public class ShoppingCartTest
    {
        [Fact]
        public void Add_create_user()
        {
            var dbService = new DbService();
            var shoppingcart = new ShoppingCart(dbService);
        }
    }
}
