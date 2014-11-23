using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chirper.ViewModels
{
    public class CheepViewModel
    {
        public int CheepId { get; set; }

        [Required]
        [RegularExpression(@"[\s\S]*[a-zA-Z0-9]+[\s\S]*", ErrorMessage = "{0} must contain at least one letter or number")]
        [Display(Name = "Cheep")]
        [StringLength(180, ErrorMessage = "{0} can only contain up to {1} characters.")]
        public string CheepText { get; set; }

        [Display(Name = "Posted On")]
        public string PostedDateTime { get; set; }
    }
}