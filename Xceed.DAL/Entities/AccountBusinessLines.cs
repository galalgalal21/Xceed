using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xceed.DAL.Entities
{
    public class AccountBusinessLines
    {
        public int id { get; set; }

        [ForeignKey("Employee")]
        public int line_Of_BusinessId { get; set; }
        public Line_of_Business? line_Of_Business { get; set; }

        [ForeignKey("account")]
        public int accountId { get; set; }
        public Account? account { get; set; }
        
    }
}
