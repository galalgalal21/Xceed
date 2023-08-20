using System.ComponentModel.DataAnnotations;

namespace Xceed.PL.Models
{
    public class LoginVM
    {
        [EmailAddress(ErrorMessage = "Invalid Mail")]
        [Required(ErrorMessage = "This Field Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This Field Required")]
        [MinLength(6, ErrorMessage = "Min Len 6")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
