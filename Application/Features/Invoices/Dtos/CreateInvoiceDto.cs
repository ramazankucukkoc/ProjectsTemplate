namespace Application.Features.Invoices.Dtos
{
    public class CreateInvoiceDto
    {
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public double TotalSum { get; set; }
        public string No { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }


    }
}
