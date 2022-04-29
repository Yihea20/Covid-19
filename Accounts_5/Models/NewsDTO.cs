using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts_5.Models
{
    public class CreateNewsDTO
    {
        public string title { get; set; }
    }

    public class NewsDTO:CreateNewsDTO
    {
        public int id { get; set; }

    }
}
