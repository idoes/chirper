using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}