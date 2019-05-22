using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Voluntis.Data;

namespace Voluntis.Areas.Backoffice.Controllers
{
    [Area("Backoffice")]
    public class DashboardController : Controller
    {
        private readonly VoluntisDbContext voluntisDbContext;
        public DashboardController(VoluntisDbContext voluntisDbContext)
        {
            this.voluntisDbContext = voluntisDbContext;
        }

        public IActionResult Index()
        {
            ViewData["Users"] = voluntisDbContext.Users;

            var categories = voluntisDbContext.Categories.ToList();
            return View(categories);
        }
    }
}