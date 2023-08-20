using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xceed.DAL.Entities
{
    public class Line_of_Business
    {
        public int id { get; set; }
        public string name { get; set; }
        //public int accountId { get; set; }
        //public Account? account { get; set; }
        public List<Employee>? Employees { get; set; }
        public List<AccountBusinessLines>? accountBusinessLines { get; set; }
    }
}
