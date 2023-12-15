using ApartmentManagementSystem.Domain.Entities;
using ApartmentManagementSystem.MVC.Models;
using ApartmentManagementSystem.Persistance.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagementSystem.MVC.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private readonly ApartmentManagementSystemDbContext _context;
        private readonly UserManager<AppUser> _UserManager;

        public UserController(ApartmentManagementSystemDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _UserManager = userManager;
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
            _context.ContactMessages.Add(contactMessage);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
