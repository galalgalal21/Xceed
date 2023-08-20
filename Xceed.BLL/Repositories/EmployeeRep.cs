using Microsoft.EntityFrameworkCore;
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
    public class EmployeeRep : GenericRepository<Employee, int>, IEmployeeRep
    {
        private readonly XceedDbContext context;

        public EmployeeRep(XceedDbContext context) : base(context)
        {
            this.context = context;
        }

        public override Task<List<Employee>> GetAll()
        {
            var data = context.Employees.Include(a => a.account).Include(l => l.line_Of_Business)
                .Include(l => l.language).Include(l => l.EmployeeLanguageLevels)
                .ThenInclude(el => el.Language_Level).ToList();
            return Task.FromResult(data);
        }

        public override Task<Employee> GetById(int id)
        {
            var data = context.Employees.Include(a => a.account).Include(l => l.line_Of_Business)
                .Include(l => l.language).Include(l => l.EmployeeLanguageLevels)
                .ThenInclude(el => el.Language_Level).FirstOrDefault(a => a.id == id);
            return Task.FromResult(data);
        }
    }
}
