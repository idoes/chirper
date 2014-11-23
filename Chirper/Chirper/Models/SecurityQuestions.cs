using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chirper.Models
{
    public class SecurityQuestions
    {
        [Required]
        [StringLength(50, ErrorMessage = "{0} cannot contain more than {1} characters")]
        [Display(Name = "Security Question One")]
        public string QuestionOne { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} cannot contain more than {1} characters")]
        [Display(Name = "Security Question Two")]
        public string QuestionTwo { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} cannot contain more than {1} characters")]
        [Display(Name = "Security Question Three")]
        public string QuestionThree { get; set; }
    }
}