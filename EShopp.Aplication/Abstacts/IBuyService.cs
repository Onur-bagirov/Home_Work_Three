namespace EShopp.Aplication.Abstacts
{
    public interface IBuyService
    {
        Task BuyAsync(int productId, int quantity);
        Task UpdateStockAsync(int productId, int quantityChange);
        Task<List<Buy>> GetAllBuyAsync();
    }
}