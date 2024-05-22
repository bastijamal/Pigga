using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PiggaProject.Models;
using PiggaProject.ViewModels;
using PiggaProject.ViewModels.Account;

namespace PiggaProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _usermanager;

        public AccountController(UserManager<User> usermanager)
        {
            _usermanager = usermanager;
        }

        public IActionResult Register()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm registerVm)
        {
            //1.Herzamanki kimi model state yoxlamaq
            if (!ModelState.IsValid) return View();


            ///2. Bize user lazimdir onu yaradir vm le beraberleshdirrik
            User user = new User()
            {
                Name=registerVm.Name,
                Email=registerVm.Email,

            };

            //parolu burda vermirik ayri verrik(resultun ichine yigiriq
            var result = await _usermanager.CreateAsync(user, registerVm.Password);
            //sonra resultun errorlarini yoxlayriq

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);

                }
            }


            //dogru olarsa Logine getsin
            return RedirectToAction("Login");
        }


        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginVm loginVm)
        {
            return View();
        }
    }
}

