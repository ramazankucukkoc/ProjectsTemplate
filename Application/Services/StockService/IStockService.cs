namespace Application.Services.StockService
{
    public interface IStockService
    {
        Task StockUpdateToProductAsync(int productId, int quantity);
    }
}
