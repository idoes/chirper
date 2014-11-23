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
        //identity in database
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]       //primary key      
        public int Id { get; set; }

        [Required]
        [StringLength(180, ErrorMessage="Cheep can only contain up to {1} characters.")]
        public string Text { get; set; }

        //create foreign key on AspNetUser table
        public AspNetUser Author { get; set; }
        public string AuthorId { get; set; }

        public DateTime PostedDateTime { get; set; }
    }
}