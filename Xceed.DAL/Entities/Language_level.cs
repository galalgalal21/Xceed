using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xceed.DAL.Entities
{
    public class Language_level
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<EmployeeLanguageLevels>? EmployeeLanguageLevels { get; set; }
    }
}
