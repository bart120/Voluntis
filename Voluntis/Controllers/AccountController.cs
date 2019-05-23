using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Voluntis.Models;
using Voluntis.Class;

namespace Voluntis.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            /*if(model.Birthdate.AddYears(18) > DateTime.Now)
            {
                ModelState.AddModelError("Birthdate", "Vous devez avoir 18 ans.");
            }*/

            if (ModelState.IsValid)
            {
                //save bdd
                var user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Birthdate = model.Birthdate,
                    Lastname = model.Lastname,
                    Firstname = model.Firstname
                };

                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home", new { area = "" });
                }
                else
                {
                    ModelState.AddModelError("", result.ToString());
                }
            }
            return View();
        }


        [HttpGet]
        public IActionResult OnLogin(string returnUrl)
        {
            TempData["URL"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnLogin(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var resultat = await signInManager.PasswordSignInAsync(model.Login, model.Password, true, true);
                if (resultat.Succeeded)
                {
                    if (!string.IsNullOrWhiteSpace(TempData["URL"]?.ToString()))
                    {
                        return Redirect(TempData["URL"].ToString());
                    }
                    else
                        return RedirectToAction("index", "home");
                }

                if (resultat.IsLockedOut)
                {
                    this.DisplayMessage("Votre compte est bloqué.", TypeMessage.DANGER);
                }
                else
                {
                    this.DisplayMessage("Login / mot de passe incorrect.", TypeMessage.DANGER);
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}