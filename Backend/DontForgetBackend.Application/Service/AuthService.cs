using DontForgetBackend.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontForgetBackend.Application.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJwtProvider _jwtProvider;
        public AuthService(IAuthRepository authRepository, IJwtProvider jwtProvider)
        {
            _authRepository = authRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task<string> Login(string? login, string? password)
        {
            var user = await _authRepository.GetByLogin(login);

            if (user.Password != password)
            {
                throw new Exception();
            }

            var token = _jwtProvider.GenerateToken(user);

            return token;
        }

        
    }
}
