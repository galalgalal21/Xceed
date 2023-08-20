using Xceed.DAL.Entities;

namespace Xceed.PL.Models
{
    public class Language_levelVM
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool IsSelected { get; set; }
        public List<EmployeeLanguageLevels>? employeeLanguages { get; set; }
    }
}
