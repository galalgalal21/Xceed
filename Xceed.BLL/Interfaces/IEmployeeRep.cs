using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.DAL.Entities;

namespace Xceed.BLL.Interfaces
{
    public interface IEmployeeRep : IGenericRepository<Employee, int>
    {
    }
}
