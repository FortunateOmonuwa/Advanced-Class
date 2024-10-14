namespace Inventory.Interfaces
{
    public interface IProductService
    {
        Task<ResponseDetail<Product>> GetProductById(int productId);
        Task<List<Product>> GetAllProducts();
        Task<ResponseDetail<Product>> AddProduct(Product product);
        Task<ResponseDetail<Product>> UpdateProduct(Product product);
        Task<ResponseDetail<string>> DeleteProduct(int productId);
        Task<ResponseDetail<string>> UpdateProducts();
    }
}
