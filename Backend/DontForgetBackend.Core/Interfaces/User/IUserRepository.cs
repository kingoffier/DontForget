using DontForgetBackend.Core.Models;

namespace DontForgetBackend.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> Get();
        Task<int> Create(UserModel model);
        Task<int> Update(int id, string? email, string? fname, string? sname, string? pass, string? login);
        Task<int> Delete(int id);
    }
}
