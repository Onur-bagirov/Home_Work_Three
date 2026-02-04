using EShopp.Domain.Entities;
namespace EShopp.Aplication.Abstracts
{
    public interface IProductService
    {
        Task AddProductAsync(Product product);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task RemoveProductAsync(int id);
        Task UpdateProductAsync(Product product);
    }
}