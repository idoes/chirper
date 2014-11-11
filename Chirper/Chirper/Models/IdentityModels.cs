using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Chirper.Models
{
    //application user class
    public class ApplicationUser : IdentityUser
    {
       
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