using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
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
            var cheeps = app_db.Cheeps.Where(x => x.AuthorId == userId).ToList();

            return cheeps as IEnumerable<Cheep>;
        }

        //method to return a user's ID from their name
        public AspNetUser GetUserByName(string userName)
        {
            var userByName = aspnet_db.AspNetUsers
                                    .Where(c => c.UserName == userName)
                                    .FirstOrDefault();

            return userByName;
        }

        //method to return a user from a user's ID
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

        public SecurityQuestions GetSecurityQuestions(string userId)
        {           
            // Get all security questions from database
            var userById = aspnet_db.AspNetUsers
                                    .Where(c => c.Id == userId)
                                    .FirstOrDefault();

            // Set questions into designated model
            SecurityQuestions securityQuestions = new SecurityQuestions()
            {
                QuestionOne = userById.SecurityQuestionOne,
                QuestionTwo = userById.SecurityQuestionTwo,
                QuestionThree = userById.SecurityQuestionThree,
            };

            return securityQuestions;
        }

        public SecurityAnswers GetSecurityAnswers(string userId)
        {
            // Get all security answer from database
            var userById = GetUserById(userId);

            // Set answers into designated model
            SecurityAnswers securityAnswers = new SecurityAnswers()
            {
                AnswerOne = userById.SecurityAnswerOne,
                AnswerTwo = userById.SecurityAnswerTwo,
                AnswerThree = userById.SecurityAnswerThree,
            };

            return securityAnswers;
        }
    }
}