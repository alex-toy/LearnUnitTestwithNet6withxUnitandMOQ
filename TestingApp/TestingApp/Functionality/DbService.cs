using TestingApp.Models;

namespace TestingApp.Functionality
{
    public class DbService : IDbService
    {
        public bool ProcessResult { get; set; }
        public Product ProductBeingProcessed { get; set; }
        public int ProductIdBeingProcessed { get; set; }

        public bool RemoveItemFromShoppingCart(int productId)
        {
            if (productId == null) return false;
            ProductIdBeingProcessed = Convert.ToInt32(productId);
            return ProcessResult;
        }

        public bool SaveItemToShoppingCart(Product product)
        {
            if (product == null) return false;
            ProductBeingProcessed = product;
            return ProcessResult;
        }
    }
}
