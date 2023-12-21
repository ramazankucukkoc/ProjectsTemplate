using Application.Services.Repositories;
using Core.Domain.Entities;

namespace Application.Services.UserService
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetByEmail(string email)
        {
            User? user = await _userRepository.GetAsync(x => x.Email.ToLower().Trim() == email.ToLower().Trim());
            return user;
        }

        public async Task<User> GetById(int id)
        {
            User? user = await _userRepository.GetAsync(x => x.Id == id);
            return user;
        }

        public async Task<User> Update(User user)
        {
            User updateUser = await _userRepository.UpdateAsync(user);
            return updateUser;
        }
    }
}
