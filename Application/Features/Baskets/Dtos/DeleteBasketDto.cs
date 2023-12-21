namespace Application.Features.Baskets.Dtos
{
    public class DeleteBasketDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string UserName { get; set; }
        public int Count { get; set; }
        public string Email { get; set; }

    }
}
