using Accounts_5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts_5.Models
{

    public class CreateVaccinationDTO
    {
        public string name { get; set; }
        public string type { get; set; }
        public int doseNumber { get; set; }
    }
    public class VaccinationDTO:CreateVaccinationDTO
    {
        public int id { get; set; }
        public IList<Person_Vaccination> Person_Vaccinations { get; set; }

        public IList<Vaccination_VaccinationCenter> Vaccination_VaccinationCenters { get; set; }

    }
}
