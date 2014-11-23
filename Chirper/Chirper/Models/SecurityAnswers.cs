using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chirper.Models
{
    public class SecurityAnswers
    {
        [Required]
        [StringLength(50, ErrorMessage = "{0} cannot contain more than {1} characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Security Answer One")]
        public string AnswerOne { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} cannot contain more than {1} characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Security Answer Two")]
        public string AnswerTwo { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} cannot contain more than {1} characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Security Answer Three")]
        public string AnswerThree { get; set; }
    }
}