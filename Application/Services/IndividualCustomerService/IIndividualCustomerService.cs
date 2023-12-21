namespace Application.Services.IndividualCustomerService
{
    public interface IIndividualCustomerService
    {
        Task<string> GetNationalId(int id);
    }
}
