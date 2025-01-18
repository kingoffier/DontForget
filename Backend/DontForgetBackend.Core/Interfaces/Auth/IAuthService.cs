using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontForgetBackend.Core.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(string? login, string? password);
    }
}
