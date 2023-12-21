namespace Application.Features.Baskets.Dtos
{
    public class BasketListDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductUnitPrice { get; set; }
        public string BrandName { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public int Count { get; set; }
    }
}
