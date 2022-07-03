using Accounts_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts_5.Services
{
    public interface IAuthoManger
    {
        Task<bool> ValidateUser(LoginPersonDTO personDTO);
        Task<string> CreatToken();
        Task<string> CreateRefreshToken();
        Task<TokenRequest> VerifyRefreshToken(TokenRequest request);
    }
}
