using System.ComponentModel.DataAnnotations;

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
        [Required]
        [StringLength(50, ErrorMessage = "{0} cannot contain more than {1} characters.")]
        [Display(Name = "Security Question One")]
        public string SecurityQuestionOne { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} cannot contain more than {1} characters.")]
        [Display(Name = "Security Answer One")]
        public string SecurityAnswerOne { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} cannot contain more than {1} characters.")]
        [Display(Name = "Security Question Two")]
        public string SecurityQuestionTwo { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} cannot contain more than {1} characters.")]
        [Display(Name = "Security Answer Two")]
        public string SecurityAnswerTwo { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} cannot contain more than {1} characters.")]
        [Display(Name = "Security Question Three")]
        public string SecurityQuestionThree { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} cannot contain more than {1} characters.")]
        [Display(Name = "Security Answer Three")]
        public string SecurityAnswerThree { get; set; }
    }
}
