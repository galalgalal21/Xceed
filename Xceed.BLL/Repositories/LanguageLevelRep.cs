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
    public class LanguageLevelRep : GenericRepository<Language_level, int>, ILanguageLevelRep
    {
        public LanguageLevelRep(XceedDbContext context) : base(context)
        {
        }
    }
}
