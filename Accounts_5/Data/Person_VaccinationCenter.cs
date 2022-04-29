using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts_5.Data
{
    public class Person_VaccinationCenter
    {

        public int id { get; set; }
       // [ForeignKey("PersonId")]
        public string PersonId { get; set; }
        public Person Person { get; set; }

        public int VaccinationCenterId { get; set; }
        public VaccinationCenter VaccinationCenter { get; set; }
    }
}
