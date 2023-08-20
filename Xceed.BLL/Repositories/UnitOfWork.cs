using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.BLL.Interfaces;
using Xceed.DAL.Contexts;

namespace Xceed.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly XceedDbContext _context;
        //private Dictionary<Type, object> _repositories;

        //public UnitOfWork(XceedDbContext context)
        //{
        //    _context = context;
        //    //_repositories = new Dictionary<Type, object>();
        //}

        //public IGenericRepository<TEntity ,TId> GetRepository<TEntity , TId>() where TEntity : class
        //{
        //    if (_repositories.ContainsKey(typeof(TEntity)))
        //    {
        //        return (IGenericRepository<TEntity, TId>)_repositories[typeof(TEntity)];
        //    }

        //    var repository = new GenericRepository<TEntity, TId>(_context);
        //    _repositories.Add(typeof(TEntity), repository);
        //    return repository;
        //}

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IEmployeeRep EmployeeRep { get; set; }
        public IAccountRep AccountRep { get; set; }
        public ILanguageRep LanguageRep { get; set; }
        public ILanguageLevelRep LanguageLevelRep { get; set; }
        public ILineOfBusinessRep LineOfBusinessRep { get; set; }
        public IEmployeeLanguageLevelsRep EmployeeLanguageLevelsRep { get; set; }

        public UnitOfWork(XceedDbContext context, IEmployeeRep employeeRep, IAccountRep accountRep, ILanguageRep languageRep, ILanguageLevelRep languageLevelRep, ILineOfBusinessRep lineOfBusinessRep, IEmployeeLanguageLevelsRep employeeLanguageLevelsRep)
        {
            EmployeeRep = employeeRep;
            AccountRep = accountRep;
            LanguageRep = languageRep;
            LanguageLevelRep = languageLevelRep;
            LineOfBusinessRep = lineOfBusinessRep;
            EmployeeLanguageLevelsRep = employeeLanguageLevelsRep;
            _context = context;
        }
    }
}
