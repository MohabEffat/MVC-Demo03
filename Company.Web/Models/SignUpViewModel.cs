using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class SignUpViewModel
    {

        [Required(ErrorMessage = "First Name Is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Is Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Format For Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{6,}$",ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, one digit, one special character, and be at least 6 characters long")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is Required")]
        [Compare(nameof(Password), ErrorMessage = "Confirm Password does not match Password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Required To Agree")]
        public bool IsAgree { get; set; }



    }
}
