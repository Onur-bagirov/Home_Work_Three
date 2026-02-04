using EShopp.Aplication.Abstacts;
using EShopp.DAL.UnitOfWork;
namespace EShopp.Aplication.Concretes
{
    public class BuyService : IBuyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BuyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task BuyAsync(int productId, int quantity)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(productId);

            if (product == null)
            {
                throw new Exception("Product not found");
            }

            if (product.StockQuantity < quantity)
            {
                throw new Exception("There are not enough products in stock");
            }

            product.StockQuantity -= quantity;

            var buy = new Buy
            {
                ProductId = product.Id,
                Quantity = quantity,
                CreatedDate = DateTime.Now
            };

            await _unitOfWork.Buys.AddAsync(buy);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateStockAsync(int productId, int quantityChange)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(productId);

            if (product == null)
            {
                return;
            }

            product.StockQuantity += quantityChange;
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<List<Buy>> GetAllBuyAsync()
        {
            var buys = await _unitOfWork.Buys.GetAllAsync();
            return buys.ToList();
        }
    }
}