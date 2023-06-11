using TestingApp.Functionality;

namespace TestingApp.Models
{
    public class ShoppingCart
    {
        private IDbService _dbService;

        public ShoppingCart(IDbService dbService)
        {
            _dbService = dbService;
        }

        public bool AddProduct(Product product)
        {
            if (product == null || product.Id == 0) return false;

            _dbService.SaveItemToShoppingCart(product);
            return true;
        }

        public bool DeleteProduct(int id)
        {
            if (id == 0) return false;

            _dbService.RemoveItemFromShoppingCart(id);
            return true;
        }
    }
}
