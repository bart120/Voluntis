using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voluntis.Class
{
    public static class ControllerExtensions
    {
        public static void DisplayMessage(this Controller controller, string message, TypeMessage type)
        {
            controller.TempData["Message"] = Newtonsoft.Json.JsonConvert.SerializeObject(new FlashMessage(message, type));
        }
    }
}
