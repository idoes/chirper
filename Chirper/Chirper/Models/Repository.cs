using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Chirper.Models
{
    //only one repository
    public class Repository : IRepository
    {
        //ASP.NET database handle
        private AspNetContext aspnet_db = new AspNetContext();

        //Application database handle
        private ApplicationDbContext app_db = new ApplicationDbContext();


        //method to get all users
        public IEnumerable<AspNetUser> GetAllUsers()
        {
            return aspnet_db.AspNetUsers.ToList();
        }

        //method to return cheeps by user ID
        public IEnumerable<Cheep> GetCheepsByUserId(string userId)
        {
            return (from c in app_db.Cheeps
                    where c.AuthorId == userId
                    select new
                    {
                        Id = c.Id,
                        Text = c.Text,
                        AuthorId = c.AuthorId,
                        PostedDateTime = c.PostedDateTime
                    }).ToList() as IEnumerable<Cheep>;
        }

        //method to return a user's ID from their name
        public AspNetUser GetUserByName(string userName)
        {
            var userByName = aspnet_db.AspNetUsers
                                    .Where(c => c.UserName == userName)
                                    .FirstOrDefault();

            return userByName;
        }

        //method to return a username from a user's ID
        public AspNetUser GetUserById(string userId)
        {
            var userById = aspnet_db.AspNetUsers
                                    .Where(c => c.Id == userId)
                                    .FirstOrDefault();

            return userById;
        }

        //method to return a username from a user's ID
        public string GetUserNameById(string userId)
        {
            var user = GetUserById(userId);

            return user.UserName;
        }

        //method to return a username from a user's ID
        public void CreateCheep(Cheep newCheep)
        {
            app_db.Cheeps.Add(newCheep);
            app_db.SaveChanges();
        }

/*ProfileControllder demands start
*/
        
        //method to return a user's first name by providing user's username
        //  which is Email value in our application's intepratation. 
        public string GetUserFirstNameById(string userId)
        {
            var user = GetUserById(userId);
            return user.FirstName;
        }

        //method to return a suser's last name by providing user's username
        //  which is Email value in our application's intepratation. 
        public string GetUserLastNameById(string userId)
        {
            var user = GetUserById(userId);
            return user.LastName;
        }

        public AspNetUser GetAspNetUserById(string userId)
        {
            return aspnet_db.AspNetUsers.Find(userId);
        }

        //method to update Table.AspNetUser
        public void UpdateUser(AspNetUser aspNetUser)
        {
            aspnet_db.Entry(aspNetUser).State = EntityState.Modified;
        }

        public void Save()
        {
            aspnet_db.SaveChanges();
        }
    }
}