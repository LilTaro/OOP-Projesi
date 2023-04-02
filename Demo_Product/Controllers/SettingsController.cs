using Demo_Product.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Demo_Product.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.Name= values.Name;
            userEditViewModel.Surname = values.Surname;
            userEditViewModel.Mail = values.Email;
            userEditViewModel.Gender = values.Gender;
            return View(userEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel P)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Name = P.Name;
            user.Surname= P.Surname;
            user.Email = P.Mail;
            user.Gender = P.Gender;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, P.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Login");
            }
            else
            {
                //hata mesajları
            }
            return View();
        }
    }
}
