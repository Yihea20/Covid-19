using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts_5.Data
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Parag { get; set; }
        public DateTime dateTime { get; set; } = DateTime.Now;
    }
}
