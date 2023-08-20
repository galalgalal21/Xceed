using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xceed.DAL.Entities;

namespace Xceed.BLL.Interfaces
{
    public interface ILineOfBusinessRep : IGenericRepository<Line_of_Business, int>
    {
        List<Line_of_Business> Get(Expression<Func<Line_of_Business, bool>> filter = null);

    }
}
