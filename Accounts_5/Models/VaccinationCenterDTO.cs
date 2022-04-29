using Accounts_5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts_5.Models
{
    public class CreateVaccinationCenterDTO
    {
        public string name { get; set; }
        public string availableVaccinations { get; set; }
        public int vaccinatedPeopleNumber { get; set; }
    }
    public class VaccinationCenterDTO : CreateVaccinationCenterDTO
    {
        public int id { get; set; }
        public  IList<Vaccination_VaccinationCenter> Vaccination_VaccinationCenters { get; set; }
        public IList<Person_VaccinationCenter> Person_VaccinationCenters { get; set; }
    }
}
