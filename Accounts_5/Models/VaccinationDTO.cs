using Accounts_5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts_5.Models
{

    public class CreateVaccinationDTO
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int DoseNumber { get; set; }
        public int AllowedAge { get; set; }
        
    }
    public class VaccinationDTO:CreateVaccinationDTO
    {
        public int Id { get; set; }
        public IList<Person_For_Vaccination> Person { get; set; }
       public IList<Center_For_Vaccination> VaccinationCenter { get; set; }

    }
    public class Vaccination_For_Center:CreateVaccinationDTO
    {

        public int Id { get; set; }
        
    }
}
