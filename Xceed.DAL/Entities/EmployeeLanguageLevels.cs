using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xceed.DAL.Entities
{
    public class EmployeeLanguageLevels
    {
        public int id { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        [ForeignKey("Language")]
        public int? LanguageId { get; set; }
        public Language? Language { get; set; }

        
        [ForeignKey("Language_Level")]
        public int Language_LevelId { get; set; }
        public Language_level? Language_Level { get; set; }
    }
}
