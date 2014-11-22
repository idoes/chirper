using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chirper.Models;
using Chirper.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data;

namespace Chirper.Controllers
{
    public class ProfileController : Controller
    {
        private IRepository _repository;

        //constructor1
        public ProfileController()
        {
            this._repository = new Repository();
        }
        //constructor 2
        public ProfileController(IRepository _repository)
        {
            this._repository = new Repository();

        }

        [Authorize]
        public ActionResult Index()
        {
            ProfileViewModel profileVM = new ProfileViewModel();

            //Httpcontext.Identity for the below two queries
            //Query DBContext for User Information
            profileVM.id = HttpContext.User.Identity.GetUserId();
            profileVM.UserName = _repository.GetUserNameById(profileVM.id);
            profileVM.FirstName = _repository.GetUserFirstNameById(profileVM.id);
            profileVM.LastName = _repository.GetUserLastNameById(profileVM.id);


            //Query DBContext for all cheeps related to this id
            //Assignment to the object of ProfileViewModel

            return View(profileVM);
        }

        public ActionResult Update(string id)
        {
            AspNetUser aspNetUser = _repository.GetAspNetUserById(HttpContext.User.Identity.GetUserId());

            return View(aspNetUser);
        }
        [HttpPost]
        public ActionResult Update(AspNetUser aspNetUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.UpdateUser(aspNetUser);
                    _repository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, " +
                  "and if the problem persists see your system administrator.");
            }
            return View(aspNetUser);
        }

        /*
                public ActionResult Friend(string id)
                {
                    var userFirstName = _repository.sth;
                    var userLastName = _repository.sth;
                    var userCheeps = _repository.GetCheepsByuserId(id);

                    ProfileViewModel profileVM = new ProfileViewModel();
                    return View(profileVM);
                }
         */
    }
}
