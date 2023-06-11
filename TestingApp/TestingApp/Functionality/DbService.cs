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
            throw new NotImplementedException();
        }

        public bool SaveItemToShoppingCart(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
