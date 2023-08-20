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
    public class AccountRep : GenericRepository<Account, int>, IAccountRep
    {
        public AccountRep(XceedDbContext context) : base(context)
        {
        }
    }
}
