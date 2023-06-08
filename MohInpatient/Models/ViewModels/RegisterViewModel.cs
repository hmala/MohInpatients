using System.ComponentModel.DataAnnotations;

namespace MohInpatient.Models.ViewModels
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage ="Enter Email")]
        [EmailAddress]
        public string? UserEmail { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Enter Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password and Confirm not match")]
        public string? ConfirmPassword { get; set; }
        [Required]
        public string? Phone { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }

    }
}
