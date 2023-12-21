using System.Text.Json.Serialization;

namespace Application.Features.Stocks.Dtos
{
    public class CreateStockDto
    {
        public int Id { get; set; }

        [JsonIgnore]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
