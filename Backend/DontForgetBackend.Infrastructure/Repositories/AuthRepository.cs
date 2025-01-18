using DontForgetBackend.Core.Interfaces;
using DontForgetBackend.Core.Models;
using DontForgetBackend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontForgetBackend.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DontForgetContext _db;
        public AuthRepository(DontForgetContext db)
        {
            _db = db;
        }
        public async Task<UserModel> GetByLogin(string? login)
        {
            var userEntity = await _db.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Login == login) ?? throw new Exception();

            var users = UserModel.Create(userEntity.Id, userEntity.Email, userEntity.FirstName, userEntity.SecondName, userEntity.Password, userEntity.Login).UserModel;

            return users;
        }
    }
}
