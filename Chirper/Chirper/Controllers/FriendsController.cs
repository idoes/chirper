using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chirper.Models;
using Chirper.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Chirper.Controllers
{
    public class FriendsController : Controller
    {
        private AspNetContext AspNetContext;
        private ApplicationDbContext AppContext;

        protected UserManager<ApplicationUser> UserManager { get; set; }

        public FriendsController()
        {
            AspNetContext = new AspNetContext();
            AppContext = new ApplicationDbContext();
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.AppContext));
        }

        // GET: Friends
        [HttpGet]
        public ActionResult Index()
        {
            var users = AspNetContext.AspNetUsers.ToList();
            return View(users);
        }

        public ActionResult Cheeps(string id)
        {
            var user = UserManager.FindById(id);

            var allCheeps = (from c in AppContext.Cheeps
                            where c.AuthorId == id
                            select new
                            {
                                c.Text,
                                c.PostedDateTime
                            }).ToList();

            if (allCheeps != null)
            {
                List<CheepViewModel> cheeps = new List<CheepViewModel>();
                foreach (var cheep in allCheeps)
                {
                    cheeps.Add(new CheepViewModel
                    {
                        CheepText = cheep.Text,
                        PostedDateTime = cheep.PostedDateTime.ToShortDateString()
                    });
                }

                FriendViewModel friend = new FriendViewModel()
                {
                    Username = user.UserName,
                    Cheeps = cheeps
                };

                return View(friend);
            }

            return View();
        }
    }
}