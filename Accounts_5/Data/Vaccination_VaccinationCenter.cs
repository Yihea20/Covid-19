using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts_5.Data
{
    public class Vaccination_VaccinationCenter
    {
        public int id { get; set; }

        //navigation prop

        public int VaccinationId { get; set; }
        public Vaccination Vaccination { get; set; }

        public int VaccinationCenterId { get; set; }
        public VaccinationCenter VaccinationCenter { get; set; }
    }
}
