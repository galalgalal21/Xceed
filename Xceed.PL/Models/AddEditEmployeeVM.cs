using System.ComponentModel.DataAnnotations;
using Xceed.DAL.Entities;
using Xceed.PL.Helper;

namespace Xceed.PL.Models
{
    public class AddEditEmployeeVM
    {
        public int id { get; set; }
        
        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name must contain only letters and spaces.")]
        public string name { get; set; }
        
        [Required(ErrorMessage = "National ID is required.")]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "National ID must be exactly 14 numbers.")]
        public long national_id { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [CustomMinimumAge(18, ErrorMessage = "Employee must be at least 18 years old.")]
        public DateTime date_of_birth { get; set; } = DateTime.Today;

        public int age { get; set; }

        [Required(ErrorMessage = "Account is required.")]
        public int accountId { get; set; }
        public List<AccountVM>? accountVMs { get; set; }
        
        [Required(ErrorMessage = "Line of Business is required.")]
        [Display(Name = "Line of Business")]
        public int line_Of_BusinessId { get; set; }
        public List<LineOfBusinessVM>? lineOfBusinessVMs { get; set; }
        
        [Required(ErrorMessage = "language is required.")]
        public int languageId { get; set; }
        public List<LanguageVM>? languageVMs { get; set; }

        public List<int> SelectedLanguageLevelIds { get; set; }

        public List<Language_levelVM>? language_LevelVMs { get; set; }
    }
}
