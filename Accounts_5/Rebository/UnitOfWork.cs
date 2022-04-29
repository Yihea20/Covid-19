using Accounts_5.Data;
using Accounts_5.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts_5.Rebository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IGenericRepository<News> _newses;
        private IGenericRepository<Vaccination> _vaccination;
        private IGenericRepository<VaccinationCenter> _vaccinationCenters;
        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public IGenericRepository<News> Newses => _newses??=new GenericRepository<News>(_context);

        public IGenericRepository<Vaccination> Vaccinaions => _vaccination??=new GenericRepository<Vaccination>(_context);

        public IGenericRepository<VaccinationCenter> VaccinationCenters => _vaccinationCenters??=new GenericRepository<VaccinationCenter>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
