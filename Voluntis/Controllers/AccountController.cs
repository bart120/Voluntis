using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Voluntis.Models;

namespace Voluntis.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;

        public AccountController(UserManager<User> userManager)
        {
            this.userManager = userManager;
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
    }
}