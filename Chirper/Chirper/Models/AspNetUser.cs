namespace Chirper.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetRoles = new HashSet<AspNetRole>();
        }

        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string SecurityQuestionOne { get; set; }

        [Required]
        [StringLength(50)]
        public string SecurityAnswerOne { get; set; }

        [Required]
        [StringLength(50)]
        public string SecurityQuestionTwo { get; set; }

        [Required]
        [StringLength(50)]
        public string SecurityAnswerTwo { get; set; }

        [Required]
        [StringLength(50)]
        public string SecurityQuestionThree { get; set; }

        [Required]
        [StringLength(50)]
        public string SecurityAnswerThree { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        [Required]
        [StringLength(128)]
        public string Discriminator { get; set; }


        //Foreign keys on other AspNet tables
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }

        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }

        public virtual ICollection<AspNetRole> AspNetRoles { get; set; }
    }
}
