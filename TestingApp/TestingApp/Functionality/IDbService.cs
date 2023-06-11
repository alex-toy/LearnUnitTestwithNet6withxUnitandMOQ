using TestingApp.Models;

namespace TestingApp.Functionality
{
    public interface IDbService
    {
        bool SaveItemToShoppingCart(Product product);
        bool RemoveItemFromShoppingCart(int productId);
    }
}
