using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Chirper.Models;
using Chirper.ViewModels;

namespace Chirper.Controllers
{
    [Authorize]
    public class FriendsController : Controller
    {
        private IRepository _repository;

        //ctors
        public FriendsController()
        {
            this._repository = new Repository();
        }

        public FriendsController(IRepository _repository)
        {
            this._repository = new Repository();
        }



        // GET: Friends
        [HttpGet]
        public ActionResult Index()
        {
            var users = _repository.GetAllUsers();
            return View(users);
        }
        /*
        [HttpGet]
        public ActionResult Cheeps(string id)
        {
            if (!String.IsNullOrWhiteSpace(id))
            {
                var friendUser = _repository.GetUserById(id);

                if (friendUser != null)
                {
                    // Found the user, 
                    FriendViewModel friend = new FriendViewModel();

                    //friend.Username = _repository.GetUserNameById(id);

                    //get all cheeps
                    var userCheeps = _repository.GetCheepsByUserId(id);

                    if (userCheeps != null)
                    {
                        List<CheepViewModel> cheeps = new List<CheepViewModel>();
                        foreach (var cheep in userCheeps)
                        {
                            cheeps.Add(new CheepViewModel
                            {
                                CheepText = cheep.Text,
                                PostedDateTime = cheep.PostedDateTime.ToShortDateString()
                            });
                        }

                        friend.Cheeps = cheeps;

                        return View(friend);
                    }

                    return View(friend);
                }
                
            }

            ViewBag.Error = "User could not be found.";
            return View("Error");
        }      */
    }
}