using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xceed.BLL.Interfaces;
using Xceed.DAL.Contexts;
using Xceed.DAL.Entities;

namespace Xceed.BLL.Repositories
{
    public class LineOfBusinessRep : GenericRepository<Line_of_Business, int>, ILineOfBusinessRep
    {
        private readonly XceedDbContext context;

        public LineOfBusinessRep(XceedDbContext context) : base(context)
        {
            this.context = context;
        }

        public List<Line_of_Business> Get(Expression<Func<Line_of_Business, bool>> filter = null)
        {
            if (filter == null)
            {
                var data = context.Line_Of_Businesses.Select(a => a).ToList();
                return data;
            }
            else
            {
                var data = context.Line_Of_Businesses.Where(filter).ToList();
                return data;
            }
        }
    }
}
