
using DontForgetBackend.Core.Interfaces;
using DontForgetBackend.Core.Models;

namespace DontForget.Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _usersRepository;
        public UserService(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<int> AddUser(UserModel model)
        {
            return await _usersRepository.Create(model);
        }

        public async Task<int> DeleteUser(int id)
        {
            return await _usersRepository.Delete(id);
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _usersRepository.Get();
        }

        public async Task<int> UpdateUser(int id, string? email, string? fname, string? sname, string? pass, string? login)
        {
            return await _usersRepository.Update(id, email, fname, sname, pass, login);
        }
    }
}
