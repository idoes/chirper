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
    [Authorize]
    public class CheepsController : Controller
    {
        private IRepository _repository;

        //ctors
        public CheepsController()
        {
            this._repository = new Repository();
        }

        public CheepsController(IRepository _repository)
        {
            this._repository = new Repository();
        }


        // GET: Cheeps
        public ActionResult Index()
        {
            var user = _repository.GetUserByName(HttpContext.User.Identity.Name);

            //Abstract into method
            var allUserCheeps = _repository.GetCheepsByUserId(user.Id);

            if (allUserCheeps != null)
            {
                List<CheepViewModel> cheeps = new List<CheepViewModel>();
                foreach (var cheep in allUserCheeps)
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
                var user = _repository.GetUserByName(HttpContext.User.Identity.Name);

                Cheep newCheep = new Cheep() {
                    Text = cheep.CheepText,
                    AuthorId = user.Id,
                    PostedDateTime = DateTime.Now
                };

                _repository.CreateCheep(newCheep);

                return RedirectToAction("Index");
            }

            return View();
        }

        
    }
}