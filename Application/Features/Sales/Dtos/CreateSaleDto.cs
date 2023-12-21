namespace Application.Features.Sales.Dtos
{
    public class CreateSaleDto
    {
        public int Quantity { get; set; }//Adet
        public decimal TotalPrice { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public string PersonelName { get; set; }
        public string BrandName { get; set; }
        public string CategroyName { get; set; }
        public string ProductBranchName { get; set; }

    }
}
