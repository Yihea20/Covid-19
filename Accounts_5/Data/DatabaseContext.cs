using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts_5.Data
{
    public class DatabaseContext:IdentityDbContext<Person>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> Option):base(Option)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person_Vaccination>()
               .HasOne(p => p.Person)
               .WithMany(pv => pv.Person_Vaccinations)
               .HasForeignKey(pi => pi.PersonId);

            modelBuilder.Entity<Person_Vaccination>()
               .HasOne(p => p.Vaccination)
               .WithMany(pv => pv.Person_Vaccinations)
               .HasForeignKey(pi => pi.VaccinationId);


            modelBuilder.Entity<Vaccination_VaccinationCenter>()
               .HasOne(v => v.Vaccination)
               .WithMany(vv => vv.Vaccination_VaccinationCenters)
               .HasForeignKey(vi => vi.VaccinationId);

            modelBuilder.Entity<Vaccination_VaccinationCenter>()
               .HasOne(v => v.VaccinationCenter)
               .WithMany(vv => vv.Vaccination_VaccinationCenters)
               .HasForeignKey(vi => vi.VaccinationCenterId);

            modelBuilder.Entity<Person_VaccinationCenter>()
               .HasOne(p => p.Person)
               .WithMany(pv => pv.Person_VaccinationCenters)
               .HasForeignKey(pi => pi.PersonId);

            modelBuilder.Entity<Person_VaccinationCenter>()
               .HasOne(p => p.VaccinationCenter)
               .WithMany(pv => pv.Person_VaccinationCenters)
               .HasForeignKey(pi => pi.VaccinationCenterId);



        }
        public DbSet<News> Newss { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<Person_Vaccination> People_Vaccinations { get; set; }
        public DbSet<VaccinationCenter> VaccinationCenters { get; set; }
        public DbSet<Vaccination_VaccinationCenter> Vaccinations_VaccinationCenters { get; set; }
        public DbSet<Person_VaccinationCenter> People_VaccinationCenters { get; set; }
    }
}
