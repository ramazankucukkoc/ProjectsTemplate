namespace Application.Features.Baskets.Dtos
{
    public class GetByBrandIdBasketDto
    {
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Count { get; set; }
        public string BrandName { get; set; }
        public string ProductName { get; set; }
        public string ParentCategoryName { get; set; }
        public string CategoryName { get; set; }
    }
}
