using Accounts_5.ConfigServices.Entity;
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
            modelBuilder.Entity<Vaccination>().HasMany(vc => vc.VaccinationCenter)
                .WithMany(v => v.Vaccinations).UsingEntity<VaccinationCenter_Vaccination>(
                vvc => vvc.HasOne(prop => prop.vaccinationCenter).WithMany().HasForeignKey(prop => prop.vaccinationCenterId),
                vvc => vvc.HasOne(prop => prop.vaccination).WithMany().HasForeignKey(prop => prop.vaccinationId),
                vvc => vvc.HasKey(prop => new { prop.vaccinationId, prop.vaccinationCenterId })
                );
            modelBuilder.Entity<Vaccination>().HasMany(vc => vc.Person)
                .WithMany(v => v.Vaccinations).UsingEntity<Person_Vaccination>(
                vvc => vvc.HasOne(prop => prop.Person).WithMany().HasForeignKey(prop => prop.PersonId),
                vvc => vvc.HasOne(prop => prop.Vaccination).WithMany().HasForeignKey(prop => prop.VaccinationId),
                vvc => vvc.HasKey(prop => new { prop.VaccinationId, prop.PersonId })
                );
            modelBuilder.Entity<VaccinationCenter>().HasMany(p => p.Person)
                .WithMany(vc => vc.VaccinationCenters).UsingEntity<Person_VaccinationCenter>(
                pv => pv.HasOne(prop => prop.Person).WithMany().HasForeignKey(prop => prop.PersonId),
                pv => pv.HasOne(prop => prop.VaccinationCenter).WithMany().HasForeignKey(prop => prop.VaccinationCenterId),
                pv => pv.HasKey(prop => new { prop.VaccinationCenterId, prop.PersonId })
                );
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
        public DbSet<News> Newss { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<Person_Vaccination> People_Vaccinations { get; set; }
        public DbSet<VaccinationCenter> VaccinationCenters { get; set; }
        public DbSet<VaccinationCenter_Vaccination> vaccinationCenter_Vaccinations { get; set; }
        public DbSet<Person_VaccinationCenter> People_VaccinationCenters { get; set; }
    }
}
