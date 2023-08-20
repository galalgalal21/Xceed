using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xceed.DAL.Entities
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public long national_id { get; set; }
        public DateTime date_of_birth { get; set; }
        //public int age { get; set; }
        public int accountId { get; set; }
        public Account? account { get; set; }
        //public List<AccountBusinessLines>? accountBusinessLines { get; set; }
        public int line_Of_BusinessId { get; set; }
        public Line_of_Business? line_Of_Business { get; set; }
        public int languageId { get; set; }
        public Language? language { get; set; }

        public List<EmployeeLanguageLevels>? EmployeeLanguageLevels { get; set; }
    }
}
