namespace Application.Services.CorporateCustomerService
{
    public interface ICorporateCustomerService
    {
        Task<string> GetTaxNumber(int id);
    }
}
