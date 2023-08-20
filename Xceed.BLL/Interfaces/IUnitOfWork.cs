using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.BLL.Repositories;

namespace Xceed.BLL.Interfaces
{
    public interface IUnitOfWork
    {
        //IGenericRepository<TEntity ,TId> GetRepository<TEntity ,TId>() where TEntity : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
        public IEmployeeRep EmployeeRep { get; set; }
        public IAccountRep AccountRep { get; set; }
        public ILanguageRep LanguageRep { get; set; }
        public ILanguageLevelRep LanguageLevelRep { get; set; }
        public ILineOfBusinessRep LineOfBusinessRep { get; set; }
        public IEmployeeLanguageLevelsRep EmployeeLanguageLevelsRep { get; set; }
    }
}
