using System.ComponentModel.DataAnnotations;

namespace Xceed.PL.Models
{
    public class RegistrationVM
    {
        [MinLength(2, ErrorMessage = "Min Len 2")]
        [Required(ErrorMessage = "This Field Required")]
        public string DisplayName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Mail")]
        [Required(ErrorMessage = "This Field Required")]
        public string Email { get; set; }

        //^01[0125][0-9]{8}$
        [Required(ErrorMessage = "This Field Required")]
        [RegularExpression("^01[0125][0-9]{8}$",
            ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "This Field Required")]
        [MinLength(6, ErrorMessage = "Min Len 6")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This Field Required")]
        [MinLength(6, ErrorMessage = "Min Len 6")]
        [Compare("Password", ErrorMessage = "Password Not Match")]
        public string ConfirmPassword { get; set; }
    }
}
