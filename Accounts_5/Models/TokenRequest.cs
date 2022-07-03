using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts_5.Models
{
    public class TokenRequest
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string rand { get; set; }
    }
}
