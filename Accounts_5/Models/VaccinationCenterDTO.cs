using Accounts_5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts_5.Models
{
    
    public class CreateVaccinationCenterDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
   
    public class VaccinationCenterDTO : CreateVaccinationCenterDTO
    {
        public int Id { get; set; }
        public IList<Vaccination_For_Center> Vaccinations { get; set; }
        public IList<Person_For_Vaccination> Person { get; set; }
    }
    public class Center_For_Vaccination : CreateVaccinationCenterDTO
    {
        public int Id { get; set; }
    }

}
