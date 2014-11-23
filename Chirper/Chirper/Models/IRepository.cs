using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chirper.Models
{
    //repository interface
    public interface IRepository
    {
        IEnumerable<AspNetUser> GetAllUsers();
        IEnumerable<Cheep> GetCheepsByUserId(string userId);
        AspNetUser GetUserByName(string userName);
        AspNetUser GetUserById(string userId);
        string GetUserNameById(string userId);
        void CreateCheep(Cheep newCheep);
        SecurityQuestions GetSecurityQuestions(string userId);
        SecurityAnswers GetSecurityAnswers(string userId);

    }
}