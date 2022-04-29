using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts_5.Data
{
    public class VaccinationCenter
    {
        public int id { get; set; }
        public string name { get; set; }
        public string availableVaccinations { get; set; }
        public int vaccinatedPeopleNumber { get; set; }
        public virtual IList<Vaccination_VaccinationCenter> Vaccination_VaccinationCenters { get; set; }
        public virtual IList<Person_VaccinationCenter> Person_VaccinationCenters { get; set; }

    }
}
