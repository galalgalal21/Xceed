using System.ComponentModel.DataAnnotations.Schema;
using Xceed.DAL.Entities;

namespace Xceed.PL.Models
{
    public class EmployeeLanguageLevelsVM
    {
        public int id { get; set; }

        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public int? LanguageId { get; set; }
        public Language? Language { get; set; }

        public int Language_LevelId { get; set; }
        public Language_level? Language_Level { get; set; }
    }
}
