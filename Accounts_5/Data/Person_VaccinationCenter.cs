using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts_5.Data
{
    public class Person_VaccinationCenter
    {

        public int Id { get; set; }
       [ForeignKey(nameof(Person))]
        public string PersonId { get; set; }
        public Person Person { get; set; }
        [ForeignKey(nameof(VaccinationCenter))]
        public int VaccinationCenterId { get; set; }
        public VaccinationCenter VaccinationCenter { get; set; }

        public DateTime dateTime { get; set; } = DateTime.Now;
    }
}
