using Core.Domain.Entities;

namespace Application.Services.UserService
{
    public interface IUserService
    {
        Task<User?> GetByEmail(string email);
        Task<User> GetById(int id);
        Task<User> Update(User user);
    }
}
