using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chirper.Models
{
    //application user class
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [StringLength(50)]
        public string SecurityQuestionOne { get; set; }
        public string SecurityQuestionTwo { get; set; }
        public string SecurityQuestionThree { get; set; }

        public string SecurityAnswerOne { get; set; }
        public string SecurityAnswerTwo { get; set; }
        public string SecurityAnswerThree { get; set; }
    }

    //application database class
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ChirperConnection")
        {
            
        }

        //Cheeps table
        public DbSet<Cheep> Cheeps { get; set; }
    }
}