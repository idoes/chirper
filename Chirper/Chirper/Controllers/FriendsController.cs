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

        [HttpGet]
        public ActionResult Cheeps(string id)
        {
            if (!String.IsNullOrWhiteSpace(id))
            {
                //get all cheeps
                var userCheeps = _repository.GetCheepsByUserId(id);

                if (userCheeps != null)
                {

                    //TODO:
                    //Create a viewmodel with the Cheeps and Friends models
                    List<CheepViewModel> cheeps = new List<CheepViewModel>();
                    foreach (var cheep in userCheeps)
                    {
                        cheeps.Add(new CheepViewModel
                        {
                            CheepText = cheep.Text,
                            PostedDateTime = cheep.PostedDateTime.ToShortDateString()
                        });
                    }

                    FriendViewModel friend = new FriendViewModel()
                    {
                        Username = _repository.GetUserNameById(id),
                        Cheeps = cheeps
                    };

                    return View(friend);
                }

                ViewBag.Error = "User has no cheeps.";
                return View("Error");
            }

            ViewBag.Error = "User could not be found.";
            return View("Error");           
        }        
    }
}