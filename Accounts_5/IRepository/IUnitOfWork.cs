using Accounts_5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts_5.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<News> Newses { get; }
        IGenericRepository<Vaccination> Vaccinaions { get; }
        IGenericRepository<VaccinationCenter> VaccinationCenters { get; }
        IGenericRepository<VaccinationCenter_Vaccination> Vaccination_VaccinationCenters { get; }
        IGenericRepository<Person_Vaccination> person_vaccination { get; }
        IGenericRepository<Person_VaccinationCenter> person_vaccinationcenter { get; }
        IGenericRepository<Person> Person { get; }
        Task Save();

    }
}
