using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts_5.Data
{
    public class VaccinationCenter_Vaccination
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Vaccination))]
        public int vaccinationId { get; set; }
        public Vaccination vaccination { get; set; }
        [ForeignKey(nameof(VaccinationCenter))]
        public int vaccinationCenterId { get; set; }
        public VaccinationCenter vaccinationCenter { get; set; }
        public DateTime dateTime { get; set; } = DateTime.Now;
    }
}
