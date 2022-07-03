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
        private IGenericRepository<Person> _person;
        private IGenericRepository<Person_Vaccination> _person_vaccination;
        private IGenericRepository<Person_VaccinationCenter> _person_vaccinationcenter;
        private IGenericRepository<Vaccination> _vaccination;
        private IGenericRepository<VaccinationCenter> _vaccinationCenters;
        private IGenericRepository<VaccinationCenter_Vaccination> _vaccination_VaccinationCenters;
        //private IGenericRepository<Person> _Person;
        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public IGenericRepository<News> Newses => _newses??=new GenericRepository<News>(_context);
        public IGenericRepository<Person> Person => _person ??= new GenericRepository<Person>(_context);
        public IGenericRepository<Vaccination> Vaccinaions => _vaccination??=new GenericRepository<Vaccination>(_context);

        public IGenericRepository<VaccinationCenter> VaccinationCenters => _vaccinationCenters??=new GenericRepository<VaccinationCenter>(_context);
       // public IGenericRepository<Person> person => _Person ??= new GenericRepository<Person>(_context);
        public IGenericRepository<Person_Vaccination> person_vaccination =>
            _person_vaccination ??= new GenericRepository<Person_Vaccination>(_context);
        public IGenericRepository<Person_VaccinationCenter> person_vaccinationcenter =>
            _person_vaccinationcenter ??= new GenericRepository<Person_VaccinationCenter>(_context);
        public IGenericRepository<VaccinationCenter_Vaccination> Vaccination_VaccinationCenters => 
           _vaccination_VaccinationCenters ??= new GenericRepository<VaccinationCenter_Vaccination>(_context);
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
