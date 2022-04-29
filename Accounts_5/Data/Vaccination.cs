using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts_5.Data
{
    public class Vaccination
    {
        public int id { get; set; }

        public string name { get; set; }
        public string type { get; set; }
        public int doseNumber { get; set; }
        //navigation prop
        public virtual IList<Person_Vaccination> Person_Vaccinations { get; set; }

        public virtual IList<Vaccination_VaccinationCenter> Vaccination_VaccinationCenters { get; set; }


    }
}
