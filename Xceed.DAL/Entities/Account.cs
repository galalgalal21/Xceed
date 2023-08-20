using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xceed.DAL.Entities
{
    public class Account
    {
        public int id { get; set; }
        public string name { get; set;}
        public List<Employee>? Employees { get; set; }
        public List<AccountBusinessLines>? accountBusinessLines { get; set; }

    }
}
