using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts_5.Models
{
    public class CreateNewsDTO
    {
        [Required]
        public string Title { get; set; }
        public string Parag { get; set; }
    }

    public class NewsDTO:CreateNewsDTO
    {
        public int Id { get; set; }
       // public DateTime dateTime { get; set; }

    }
}
