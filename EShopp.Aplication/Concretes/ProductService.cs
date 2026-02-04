using EShopp.Aplication.Abstracts;
using EShopp.DAL.UnitOfWork;
using EShopp.Domain.Entities;
namespace EShopp.Aplication.Concretes
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddProductAsync(Product product)
        {
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _unitOfWork.Products.GetAllAsync();
        }
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _unitOfWork.Products.GetByIdAsync(id);
        }
        public async Task RemoveProductAsync(int id)
        {
            _unitOfWork.Products.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}