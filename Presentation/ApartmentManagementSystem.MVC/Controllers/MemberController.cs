using ApartmentManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace ApartmentManagementSystem.MVC.Controllers
{
    public class MemberController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IToastNotification _toastNotification;

        public MemberController(SignInManager<AppUser> signInManager, IToastNotification toastNotification)
        {
            _signInManager = signInManager;
            _toastNotification = toastNotification;
        }
        public async Task<IActionResult> LogOut()
        {

            await _signInManager.SignOutAsync();
            _toastNotification.AddSuccessToastMessage("Çıkıs yapıldı...");
            return RedirectToAction("index", "Home");

        }
        public async Task<IActionResult> AccessDenied(string ReturnUrl)
        {
            string message = string.Empty;
            ViewBag.message = "Bu sayfayı görmeye yetkiniz yoktur. Yetki almak için yöneticiniz ile konuşunuz.";
            return View();
        }
    }
}
