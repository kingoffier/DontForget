using DontForgetBackend.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontForgetBackend.Core.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(UserModel model);
    }
}
