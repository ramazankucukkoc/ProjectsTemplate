namespace WebAPI.Dtos
{
    public class CreateBasketCommandModelDto
    {
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public int Count { get; set; }
    }
}
