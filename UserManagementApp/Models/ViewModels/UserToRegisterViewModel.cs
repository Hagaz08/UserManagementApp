using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UserManagementApp.Models.ViewModels
{
    public class UserToRegisterViewModel
    {
        [Required]
        [StringLength(15,MinimumLength =2,ErrorMessage ="First Name must be between 2-15 characters")]
        public string Firstname { get; set; } = string.Empty;
        [Required]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Last Name must be between 2-15 characters")]
        public string Lastname { get; set; }= string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; }= string.Empty;
        
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }=string.Empty;
        [DataType(DataType.Password)]
        [Required]
        [DisplayName("Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;

    }
}
