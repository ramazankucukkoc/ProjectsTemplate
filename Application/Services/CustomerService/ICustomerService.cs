using Domain.Entities;

namespace Application.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<Customer?> GetByUserId(int userId);

    }
}
