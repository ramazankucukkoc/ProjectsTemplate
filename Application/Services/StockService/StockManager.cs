using Application.Services.Repositories;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Domain.Entities;

namespace Application.Services.StockService
{
    public class StockManager : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockManager(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task StockUpdateToProductAsync(int productId, int quantity)
        {
            Stock? stock = await _stockRepository.GetAsync(s => s.ProductId == productId);
            if (stock == null) throw new NotFoundException("Bu ürününün stoku kalmamıştır.");

            stock.Quantity = quantity;
            await _stockRepository.UpdateAsync(stock);
        }
    }
}
