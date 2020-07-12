using System.ComponentModel.DataAnnotations;

namespace test.ViewModels
{
    public class RegisterView
    {
        [Required]
        [Display(Name="User Name")]
        [MinLength(5)]
        public string UserName { get; set; }
        [Required]
        [Display(Name="Email")]
        [EmailAddress]
        public string UserEmail { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
    }
}