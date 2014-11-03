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
    public class CheepsController : Controller
    {
        private ApplicationDbContext AppContext;
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public CheepsController()
        {
            AppContext = new ApplicationDbContext();
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.AppContext));
        }

        // GET: Cheeps
        public ActionResult Index()
        {
            var user = UserManager.FindByName(HttpContext.User.Identity.Name);

            //Abstract into method
            var allCheeps = (from c in AppContext.Cheeps
                            where c.AuthorId == user.Id
                            select new
                            {
                                c.Id,
                                c.Text,
                                c.PostedDateTime
                            });

            if (allCheeps != null)
            {
                List<CheepViewModel> cheeps = new List<CheepViewModel>();
                foreach (var cheep in allCheeps)
                {
                    cheeps.Add(new CheepViewModel
                    {
                        CheepId = cheep.Id,
                        CheepText = cheep.Text,
                        PostedDateTime = cheep.PostedDateTime.ToShortDateString()
                    });
                }
                return View(cheeps);
            }

            return View();
           
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "CheepText, PostedDateTime")]CheepViewModel cheep)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.FindByName(HttpContext.User.Identity.Name);

                Cheep newCheep = new Cheep() {
                    Text = cheep.CheepText,
                    AuthorId = user.Id,
                    PostedDateTime = DateTime.Now
                };

                AppContext.Cheeps.Add(newCheep);
                AppContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        
    }
}