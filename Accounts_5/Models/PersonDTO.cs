using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts_5.Models
{
   
        public class LoginPersonDTO
        {
        public string id { get; set; }

        [Required]
            [StringLength(50, ErrorMessage = "Your Password is limited {4}to{15} Charcters", MinimumLength = 6)]
            public string Password { get; set; }

        }
        public class PersonDTO : LoginPersonDTO
        {

            public string Name { get; set; }
            [DataType(DataType.PhoneNumber)]
            public string PhoneNumber { get; set; }
              public bool isVaccinated { get; set; }
            public ICollection<string> roleName { get; set; } 
        }
    public class Person_For_Vaccination
    {
        public string id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

    }


}
