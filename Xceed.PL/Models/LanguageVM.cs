using Xceed.DAL.Entities;

namespace Xceed.PL.Models
{
    public class LanguageVM
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<EmployeeLanguageLevels>? employeeLanguages { get; set; }
    }
}
