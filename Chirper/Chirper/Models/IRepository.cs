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
        string GetUserNameById(string userId);
        void CreateCheep(Cheep newCheep);
        
        //ProfileControllder Demands
        string GetUserFirstNameById(string userId);
        string GetUserLastNameById(string userId);
        AspNetUser GetAspNetUserById(string userId);
        void UpdateUser(AspNetUser aspNetUser);
        void Save();
    }
}