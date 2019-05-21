using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Voluntis.Models;

namespace Voluntis.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            /*if(model.Birthdate.AddYears(18) > DateTime.Now)
            {
                ModelState.AddModelError("Birthdate", "Vous devez avoir 18 ans.");
            }*/

            if (ModelState.IsValid)
            {
                //save bdd
            }
            return View();
        }
    }
}