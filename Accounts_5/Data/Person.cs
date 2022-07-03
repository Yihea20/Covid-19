using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts_5.Data
{
    public class Person:IdentityUser
    {
        public string name { get; set; }
        public string disease { get; set; }
        public bool isVaccinated { get; set; } = false;
        //navigation prop
        public virtual IList<Vaccination> Vaccinations { get; set; }
        public virtual IList<VaccinationCenter> VaccinationCenters { get; set; }
    }
}
