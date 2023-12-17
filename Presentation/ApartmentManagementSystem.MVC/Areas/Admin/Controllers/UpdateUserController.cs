using Microsoft.AspNetCore.Mvc;
using ApartmentManagementSystem.Domain.Entities;
using ApartmentManagementSystem.MVC.Models;
using ApartmentManagementSystem.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using ApartmentManagementSystem.Persistance.Context;

namespace ApartmentManagementSystem.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class UpdateUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager; // Assuming UserManager<AppUser> is available
        private readonly ApartmentManagementSystemDbContext _context;
        public UpdateUserController(UserManager<AppUser> userManager, ApartmentManagementSystemDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: /Admin/UpdateUser/Edit
        public async Task<IActionResult> UpdateUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var model = new UpdateUserViewModel
            {
                FirstName = user.firstName,
                LastName = user.lastName,
                Email = user.Email
            };

            return View(model);
        }

        // POST: /Admin/UpdateUser/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUser(string id, UpdateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userToUpdate = await _userManager.FindByIdAsync(id);

            if (userToUpdate == null)
            {
                return NotFound();
            }

            userToUpdate.firstName = model.FirstName;
            userToUpdate.lastName = model.LastName;
            userToUpdate.Email = model.Email;

            var result = await _userManager.UpdateAsync(userToUpdate);

            if (result.Succeeded)
            {
                // Update successful, redirect to a success page or another action
                return RedirectToAction("UserList", "Home");
            }
            else
            {
                // If update fails, add errors to ModelState and return the view
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }

 
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var userToDelete = await _userManager.FindByIdAsync(id);
            var daire = _context.daires.FirstOrDefault(x => x.user.Id.ToString() == id);

            if (userToDelete == null)
            {
                return NotFound();
            }
            
            var result = await _userManager.DeleteAsync(userToDelete);

            if (result.Succeeded)
            {
                return RedirectToAction("UserList", "Home"); // Redirect to user list or another action
            }
            else
            {
                // Handle deletion failure
                // You can add errors to ModelState and return a view or redirect to an error page
                return RedirectToAction("Error");
            }
        }

        

        /*
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var userToHide = await _userManager.FindByIdAsync(id);

            if (userToHide == null)
            {
                return NotFound();
            }

            userToHide.IsActive = false; //  hide/deactivate 
            var result = await _userManager.UpdateAsync(userToHide);

            if (result.Succeeded)
            {
                return RedirectToAction("UserList", "Home"); // Redirect to user list or another action
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
        */


    }
}
