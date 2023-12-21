namespace Application.Features.Baskets.Dtos
{
    public class UpdateBasketDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public int UserId { get; set; }
        public int Count { get; set; }
    }
}
