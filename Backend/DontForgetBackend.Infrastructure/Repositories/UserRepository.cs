using DontForgetBackend.Core.Interfaces;
using DontForgetBackend.Core.Models;
using DontForgetBackend.Infrastructure.Data;
using DontForgetBackend.Infrastructure.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontForgetBackend.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DontForgetContext _db;
        public UserRepository(DontForgetContext db)
        {
            _db = db;
        }

        public async Task<int> Create(UserModel model)
        {
            var userEntity = new UserEntity
            {
                Id = model.Id,
                Email = model.Email,
                FirstName = model.FirstName,
                SecondName = model.SecondName,
                Password = model.Password,
                Login = model.Login
            };

            await _db.Users.AddAsync(userEntity);
            await _db.SaveChangesAsync();

            return userEntity.Id;
        }

        public async Task<int> Delete(int id)
        {
            await _db.Users
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }

        public async Task<List<UserModel>> Get()
        {
            var userEntities = await _db.Users
                .AsNoTracking()
                .ToListAsync();

            var users = userEntities
                .Select(b => UserModel.Create(b.Id, b.Email, b.FirstName, b.SecondName, b.Password, b.Login).UserModel)
                .ToList();

            return users;
        }

        public async Task<int> Update(int id, string? email, string? fname, string? sname, string? pass, string? login)
        {
            await _db.Users
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Email, b => email)
                .SetProperty(b => b.FirstName, b => fname)
                .SetProperty(b => b.SecondName, b => sname)
                .SetProperty(b => b.Password, b => pass)
                .SetProperty(b => b.Login, b => login)
                );

            return id;
        }
    }
}
