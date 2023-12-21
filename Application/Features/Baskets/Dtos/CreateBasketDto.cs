namespace Application.Features.Baskets.Dtos
{
    public class CreateBasketDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public int UserId { get; set; }
        public int Count { get; set; }
    }
}
