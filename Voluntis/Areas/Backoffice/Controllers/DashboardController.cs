using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [Authorize]
        public async Task<IActionResult> Index()
        {
            ViewData["Users"] = await voluntisDbContext.Users.ToListAsync();

            var categories = await voluntisDbContext.Categories.ToListAsync();
            return View(categories);
        }
    }
}