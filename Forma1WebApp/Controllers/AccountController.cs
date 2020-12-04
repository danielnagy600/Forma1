﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forma1WebApp.Controllers
{
    public class AccountController : Controller
    {
        
        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated) 
            {
                return RedirectToAction("EditableList","App");
            }
            return View();
        }

      
    }
}
