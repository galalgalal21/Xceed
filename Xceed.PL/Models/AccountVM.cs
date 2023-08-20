using Xceed.DAL.Entities;

namespace Xceed.PL.Models
{
    public class AccountVM
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Employee>? Employees { get; set; }
        public List<AccountBusinessLines>? accountBusinessLines { get; set; }
    }
}
