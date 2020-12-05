using Forma1WebApp.Data.Entities;
using Forma1WebApp.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forma1WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<StoreUser> signInManager;

        public AccountController(SignInManager<StoreUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        
        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated) 
            {
                return RedirectToAction("EditableList","App");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                var result = await signInManager.PasswordSignInAsync(model.Username,
                                                                     model.Password,
                                                                     false,
                                                                     false);
                if (result.Succeeded)
                {
                    return RedirectToAction("EditableList", "App");
                }
            }
            ModelState.AddModelError("", "Sikertelen bejelentkezés");
            return View();
        }

     
        public async Task<ActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","App");
        }
    }
}
