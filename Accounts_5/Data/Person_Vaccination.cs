﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts_5.Data
{
    public class Person_Vaccination
    {
        public int Id { get; set; }
      [ForeignKey(nameof(Person))]
        public string PersonId { get; set; }
        public Person Person { get; set; }
        [ForeignKey(nameof(Vaccination))]
        public int VaccinationId { get; set; }
        public Vaccination Vaccination { get; set; }
        public DateTime dateTime { get; set; } = DateTime.Now;
    }
}
