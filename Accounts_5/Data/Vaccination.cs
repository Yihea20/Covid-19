using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Accounts_5.Data
{
    public class Vaccination
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DosesNumber { get; set; }
        public string Type { get; set; }
        public int AllowedAge { get; set; }
        public DateTime dateTime { get; set; } = DateTime.Now;

        //navigation prop 
        [JsonIgnore]
        public virtual IList<Person> Person { get; set; }
        [JsonIgnore]
        public virtual IList<VaccinationCenter> VaccinationCenter{ get; set; }


    }
}
