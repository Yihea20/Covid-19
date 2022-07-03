using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts_5.Models
{
    public class Just_CenterDTO
    {
        public int VaccinationCenterId { get; set; }
    }

    public class Person_VcccinationCenterDTO:Just_CenterDTO
    {
        public string PersonId { get; set; }
       
    }
}
