using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;
using Hotel_Booking.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hotel_Booking.Controllers
{
    public class Account : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public Account(UserManager<User> userManager, SignInManager<User> signIn)
        {
            _userManager = userManager;
            _signInManager = signIn;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Registration registration)
        {
            if(ModelState.IsValid)
            {
                User _user = new User()
                {
                    FirstName = registration.FirstName,
                    LastName = registration.LastName,
                    Email = registration.Email,
                    PasswordHash = registration.Password,
                    UserName = registration.FirstName + registration.LastName
                };

                IdentityResult result = await _userManager.CreateAsync(_user, registration.Password);

                if(result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(_user, "NUser");

                    await _signInManager.SignInAsync(_user, false);

                    return RedirectToAction(nameof(Index), "Home");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(registration);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginData loginData)
        {
            if(ModelState.IsValid)
            {
                User _user = await _userManager.FindByNameAsync(loginData.UserName);

                if(_user is not null)
                {
                    bool check = await _userManager.CheckPasswordAsync(_user, loginData.Password);
                    
                    if(check)
                    {
                        await _signInManager.SignInAsync(_user, loginData.RememberMe);
                        
                        return RedirectToAction(nameof(Index), "Home");
                    }
                }
                ModelState.AddModelError("", "UserName or Password is Wrong!");
            }
            return View(loginData);
        }

        public IActionResult FLogout()
        {
            _signInManager.SignOutAsync();

            return RedirectToAction(nameof(Logout));
        }

        public IActionResult Logout()
        {
            return View(nameof(Login));
        }
    }
}