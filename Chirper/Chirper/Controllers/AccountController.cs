using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Chirper.Models;
using Chirper.ViewModels;

namespace Chirper.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IRepository _repository;

        public AccountController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
            this._repository = new Repository();
        }

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            this._repository = new Repository();
            UserManager = userManager;

            //set user validation property to allow more than alphnum characters
            //for setting the email address as the username
            UserManager.UserValidator = new UserValidator<ApplicationUser>(UserManager) { AllowOnlyAlphanumericUserNames = false };
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindAsync(model.UserName, model.Password);
                if (user != null)
                {
                    await SignInAsync(user, model.RememberMe);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }


        //
        // POST: /Account/Register
        [HttpPost]                      
        [AllowAnonymous]                
        [ValidateAntiForgeryToken]      
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Create a new user with the given fields
                var user = new ApplicationUser() { 
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    SecurityQuestionOne = model.SecurityQuestions.QuestionOne,
                    SecurityAnswerOne = UserManager.PasswordHasher.HashPassword(model.SecurityAnswers.AnswerOne),
                    SecurityQuestionTwo = model.SecurityQuestions.QuestionTwo,
                    SecurityAnswerTwo = UserManager.PasswordHasher.HashPassword(model.SecurityAnswers.AnswerTwo),
                    SecurityQuestionThree = model.SecurityQuestions.QuestionThree,
                    SecurityAnswerThree = UserManager.PasswordHasher.HashPassword(model.SecurityAnswers.AnswerThree)
                };

                //Add the user to the persistent data store
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //We were successful, so sign the user in and redirect them
                    //to the home page of the application
                    await SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //We were not successful, so add the error to the ModelState
                    AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }



        //
        // GET: /Account/Manage
        public ActionResult Manage(ManageMessageId? message)
        {
            //result message
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";
            ViewBag.HasLocalPassword = HasPassword();

            // Get user's security questions from the data store
            var securityQuestions =  _repository.GetSecurityQuestions(User.Identity.GetUserId());

            // Check for null
            if (securityQuestions != null)
            {
                // Check for not null and not empty strings
                if (!String.IsNullOrWhiteSpace(securityQuestions.QuestionOne) &&
                !String.IsNullOrWhiteSpace(securityQuestions.QuestionTwo) &&
                !String.IsNullOrWhiteSpace(securityQuestions.QuestionThree))
                {
                    // Set ViewBag property. Could use a ViewModel, 
                    // but again, convenient ^_^
                    /*
                    ViewBag.SecurityQuestionOne = securityQuestions.QuestionOne;
                    ViewBag.SecurityQuestionTwo = securityQuestions.QuestionTwo;
                    ViewBag.SecurityQuestionThree = securityQuestions.QuestionThree;
                    */

                    ManageUserViewModel mvm = new ManageUserViewModel()
                    {
                        SecurityQuestions = new SecurityQuestions()
                        {
                            QuestionOne = securityQuestions.QuestionOne,
                            QuestionTwo = securityQuestions.QuestionTwo,
                            QuestionThree = securityQuestions.QuestionThree
                        }
                    };

                    ViewBag.ReturnUrl = Url.Action("Manage");
                    return View(mvm);
                }
            }

            ViewBag.ErrorMessage = "Could not retrieve security questions. Password reset disabled.";
            return View();
           
        }

        //
        // POST: /Account/Manage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Manage(ManageUserViewModel model)
        {
            //check if user has password
            bool hasPassword = HasPassword();
            ViewBag.HasLocalPassword = hasPassword;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasPassword)
            {
                if (ModelState.IsValid)
                {
                    SecurityQuestions storedQuestions = _repository.GetSecurityQuestions(User.Identity.GetUserId());
                    model.SecurityQuestions = storedQuestions;

                    SecurityAnswers storedAnswers = _repository.GetSecurityAnswers(User.Identity.GetUserId());

                    var verifyAnswerOne = UserManager.PasswordHasher.VerifyHashedPassword(storedAnswers.AnswerOne, model.SecurityAnswers.AnswerOne);
                    var verifyAnswerTwo = UserManager.PasswordHasher.VerifyHashedPassword(storedAnswers.AnswerTwo, model.SecurityAnswers.AnswerTwo);
                    var verifyAnswerThree = UserManager.PasswordHasher.VerifyHashedPassword(storedAnswers.AnswerThree, model.SecurityAnswers.AnswerThree);

                    if (verifyAnswerOne == PasswordVerificationResult.Success &&
                        verifyAnswerTwo == PasswordVerificationResult.Success &&
                        verifyAnswerThree == PasswordVerificationResult.Success)
                    {
                        //create new identity with updated password
                        IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                        }
                        else
                        {
                            //otherwise add ModelState error
                            AddErrors(result);
                        }
                    }

                    else
                    {
                        ViewBag.ErrorMessage = "One or more security answers are incorrect.";
                        ModelState.AddModelError("", "One or more security answers are incorrect.");
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
       

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && UserManager != null)
            {
                UserManager.Dispose();
                UserManager = null;
            }
            base.Dispose(disposing);
        }



        /*** Begin helper methods ***/

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        //instantiate auth manager
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        //asyncronous login
        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        //add errors to the current ModelState
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        //determine if the user has a password
        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        //enum for status message
        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            MissingSecurityQuestions,
            Error
        }

        //method for redirecting to local URL
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
   
        #endregion
    }
}