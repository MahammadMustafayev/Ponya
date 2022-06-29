using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ponya_Back.DAL;
using Ponya_Back.Models;
using Ponya_Back.Utilities;
using Ponya_Back.ViewModel.Authoraztion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ponya_Back.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _usermanager;
        private readonly SignInManager<AppUser> _signInmanager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(UserManager<AppUser> usermanager,SignInManager<AppUser> signInmanager,RoleManager<IdentityRole> roleManager)
        {
            _usermanager = usermanager;
            _signInmanager = signInmanager;
            _roleManager = roleManager;
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInVM signIn ,string ReturnUrl)
        {
            AppUser user;
            if (signIn.UsernameorEmail.Contains("@"))
            {
                user = await _usermanager.FindByEmailAsync(signIn.UsernameorEmail);
            }
            else
            {
                user = await _usermanager.FindByNameAsync(signIn.UsernameorEmail);
            }
            if(user == null)
            {
                ModelState.AddModelError("", "Password and Name is incorrect");
                return View(signIn);
            }
            var result = await _signInmanager.PasswordSignInAsync(user, signIn.Password, signIn.RememberMe, true);
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Sınama cəhdini aşdınız. Zəhmət olmasa biraz gözləyin");
                return View(signIn);
            }
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Login və ya parol yalnışdır");
                return View(signIn);
            }
            if (ReturnUrl != null) return LocalRedirect(ReturnUrl);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View();
            AppUser appUser = new AppUser
            {
                Name=register.FirstName,
                SurName=register.LastName,
                Email=register.Email,
                UserName=register.Username
            };
            IdentityResult result = await _usermanager.CreateAsync(appUser, register.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            await _usermanager.AddToRoleAsync(appUser, UserRoles.Admin.ToString());
            return RedirectToAction("Index", "Home");
        }
        public  async Task<IActionResult> SignOut()
        {
            await _signInmanager.SignOutAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task CreateRoles()
        {
            foreach (var item in Enum.GetValues(typeof(UserRoles)))
            {
                if (!await _roleManager.RoleExistsAsync(item.ToString())) await _roleManager.CreateAsync(new IdentityRole(item.ToString()));
            }
        }
    }
}
