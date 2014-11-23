using System.ComponentModel.DataAnnotations;
using Chirper.Models;

namespace Chirper.ViewModels
{
    //Viewmodel for managing password reset
    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        //Security questions
        public SecurityQuestions SecurityQuestions { get; set; }
       
        // Security Answers
        public SecurityAnswers SecurityAnswers { get; set; }
    }

    //Viewmodel for user login
    public class LoginViewModel
    {
        //email address as username
        [Required]
        [Display(Name = "Email")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    //Viewmodel for registering new users
    public class RegisterViewModel
    {
        //First name
        [Required]
        [StringLength(50, ErrorMessage = "{0} cannot contain more than {1} characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        //Last name
        [Required]
        [StringLength(50, ErrorMessage = "{0} cannot contain more than {1} characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        //email address as username
        [Required]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "{0} cannot contain more than {1} characters.")]
        [Display(Name = "Email")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        
        //Security questions
        public SecurityQuestions SecurityQuestions { get; set; }

        // Security Answers
        public SecurityAnswers SecurityAnswers { get; set; }
    }
}
