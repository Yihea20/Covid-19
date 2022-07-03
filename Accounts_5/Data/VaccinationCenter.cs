using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Accounts_5.Data
{
    public class VaccinationCenter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime dateTime { get; set; } = DateTime.Now;
        [JsonIgnore]
        public virtual IList<Vaccination> Vaccinations { get; set; }
        [JsonIgnore]
        public virtual IList<Person> Person { get; set; }

    }
}
