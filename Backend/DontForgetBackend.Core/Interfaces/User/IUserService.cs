using DontForgetBackend.Core.Models;

namespace DontForgetBackend.Core.Interfaces
{
    public interface IUserService
    {
        Task<List<UserModel>> GetAllUsers();
        Task<int> AddUser(UserModel model);
        Task<int> UpdateUser(int id, string? email, string? fname, string? sname, string? pass, string? login);
        Task<int> DeleteUser(int id);
    }
}
