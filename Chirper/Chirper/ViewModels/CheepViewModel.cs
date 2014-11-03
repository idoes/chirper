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

        [Display(Name = "Cheep")]
        [StringLength(180, ErrorMessage = "Cheep can only contain up to {1} characters.")]
        public string CheepText { get; set; }

        [Display(Name = "Posted On")]
        public string PostedDateTime { get; set; }
    }
}