using Shop.Domain;

namespace Shop.MVC.Interfaces
{
    public interface IProductService
    {
        public Task<List<Product>> SearchProducts(string searchTerm, int? minimumPrice, int? maximumPrice,
            int? categoryID, int? sortBy, int? pageNo, int pageSize, List<int> pictureIDs);
        public Task<int> SearchProductsCount(string searchTerm, int? minimumPrice, int? maximumPrice,
            int? categoryID, int? sortBy, List<int> pictureIDs);

    }
}
