using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Chirper.Models
{
    public class Cheep
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]       
        public int Id { get; set; }

        [StringLength(180, ErrorMessage="Cheep can only contain up to {1} characters.")]
        public string Text { get; set; }

        public AspNetUser Author { get; set; }
        public string AuthorId { get; set; }

        public DateTime PostedDateTime { get; set; }
    }
}