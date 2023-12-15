using ApartmentManagementSystem.Domain.Entities;
using ApartmentManagementSystem.MVC.Areas.Admin.Models;
using ApartmentManagementSystem.Persistance.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagementSystem.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApartmentManagementSystemDbContext _context;

        public HomeController(UserManager<AppUser> userManager, ApartmentManagementSystemDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> UserList()
        {
            var userList = await _userManager.Users.ToListAsync();
            var userViewModelList = new List<UserViewModel>();

            foreach (var user in userList)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var userViewModel = new UserViewModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.UserName
                };

                if (userRoles != null && userRoles.Any())
                {
                    userViewModel.Roles = userRoles.ToArray();
                }
                else
                {
                    userViewModel.Roles = new string[] { "No roles" }; // Eğer roller boşsa varsayılan bir değer atanabilir
                }

                userViewModelList.Add(userViewModel);
            }

            return View(userViewModelList);
        }
        [HttpGet]
        public IActionResult ContactMessages()
        {
            var contactMessages = _context.ContactMessages.ToList();
            return View(contactMessages);

        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var contact = _context.ContactMessages.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();

            _context.ContactMessages.Remove(contact);

            _context.SaveChanges();

            return RedirectToAction("ContactMessages");

        }
    }
}
