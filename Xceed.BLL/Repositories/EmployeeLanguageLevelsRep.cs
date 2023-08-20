using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.BLL.Interfaces;
using Xceed.DAL.Contexts;
using Xceed.DAL.Entities;

namespace Xceed.BLL.Repositories
{
    public class EmployeeLanguageLevelsRep : GenericRepository<EmployeeLanguageLevels, int>, IEmployeeLanguageLevelsRep
    {
        private readonly XceedDbContext context;

        public EmployeeLanguageLevelsRep(XceedDbContext context) : base(context)
        {
            this.context = context;
        }

        public Task<List<EmployeeLanguageLevels>> GetByEmployeeId(int id)
        {
            var data = context.EmployeeLanguageLevels.Where(a => a.EmployeeId == id).ToList();
            return Task.FromResult(data);
        }

        

    }
}
