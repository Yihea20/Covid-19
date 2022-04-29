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
        Task Save();

    }
}
