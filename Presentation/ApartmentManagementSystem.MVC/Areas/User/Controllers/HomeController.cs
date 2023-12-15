using ApartmentManagementSystem.Domain.Entities;
using ApartmentManagementSystem.MVC.Areas.User.Models;
using ApartmentManagementSystem.Persistance.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace ApartmentManagementSystem.MVC.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class HomeController : Controller
    {
        private readonly ApartmentManagementSystemDbContext _context;
        private readonly UserManager<AppUser> _UserManager;
        private readonly IToastNotification _toastNotification;

        public HomeController(ApartmentManagementSystemDbContext context, UserManager<AppUser> userManager, IToastNotification toastNotification)
        {
            _context = context;
            _UserManager = userManager;
            _toastNotification = toastNotification;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(ContactModel contactModel)
        {
            if (!ModelState.IsValid)
            {
                return View(contactModel);
            }

            var userId = _UserManager.GetUserId(User); // Kullanıcının Id'sini almak
            var user = await _UserManager.FindByIdAsync(userId); // Kullanıcının tam bilgilerini almak

            var contactMessage = new ContactMessage
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Name = user.firstName, // Kullanıcının adını almak
                Email = user.Email,
                Message = contactModel.Message,
                CreatedAt = DateTime.UtcNow
            };

            // Entity Framework veya veri erişim yönteminize göre veriyi veritabanına kaydedin.
            _toastNotification.AddSuccessToastMessage("Mesajınız başarıyla yöneticiye iletilmiştir.");
            _context.ContactMessages.Add(contactMessage);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
