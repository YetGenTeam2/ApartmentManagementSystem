﻿using ApartmentManagementSystem.Domain.Entities;
using ApartmentManagementSystem.MVC.Areas.Admin.Models;
using ApartmentManagementSystem.MVC.Extentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagementSystem.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly RoleManager<AppRole> _roleManager;
        public RolesController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager = null)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task<IActionResult> Index()
        {
            {
                var roles = await _roleManager.Roles.Select(x => new RoleViewModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();
                return View(roles);
            }
        }

        public IActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleCreateViewModel request)
        {
            var result = await _roleManager.CreateAsync(new AppRole()
            {
                Name = request.Name

            });
            if (!result.Succeeded)
            {
                ModelState.AddModelErrorList(result.Errors);
                return View();
            }

            TempData["SuccessMessage"] = "Rol eklenmiştir.";
            return RedirectToAction(nameof(RolesController.Index));

        }

        public async Task<IActionResult> RoleUpdate(string id)
        {
            var roleToUpdate = await _roleManager.FindByIdAsync(id);

            if (roleToUpdate == null)
            {
                throw new Exception("Güncellenecek Rol Bulunamadı.");
            }
            return View(new RoleUpdateViewModel() { Id = roleToUpdate.Id, Name = roleToUpdate.Name });
        }
        [HttpPost]
        public async Task<IActionResult> RoleUpdate(RoleUpdateViewModel request)
        {
            var roleToUpdate = await _roleManager.FindByIdAsync(request.Id);

            if (roleToUpdate == null)
            {
                throw new Exception("Güncellenecek Rol Bulunamadı.");
            }

            roleToUpdate.Name = request.Name;

            await _roleManager.UpdateAsync(roleToUpdate);

            ViewData["SuccessMessage"] = "Rol bilgisi güncellenmiştir.";

            return View();
        }

        public async Task<IActionResult> AssingRoleToUser(string id)
        {
            var currentUser = (await _userManager.FindByIdAsync(id))!;
            ViewBag.userId = id;
            var roles = await _roleManager.Roles.ToListAsync();
            var roleViewModelList = new List<AssignRoleToUserViewModel>();
            var userRoles = await _userManager.GetRolesAsync(currentUser);

            foreach (var role in roles)
            {
                var assignRoleToUserViewModel = new AssignRoleToUserViewModel() { Id = role.Id, Name = role.Name! };

                if (userRoles.Contains(role.Name!))
                {
                    assignRoleToUserViewModel.Exist = true;
                }

                roleViewModelList.Add(assignRoleToUserViewModel);
            }

            return View(roleViewModelList);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRoleToUser(string userId, List<AssignRoleToUserViewModel> requestList)
        {
            var userToAssignRoles = (await _userManager.FindByIdAsync(userId))!;

            foreach (var role in requestList)
            {
                if (role.Exist)
                {
                    await _userManager.AddToRoleAsync(userToAssignRoles, role.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(userToAssignRoles, role.Name);
                }
            }

            return RedirectToAction("UserList", "Home");
        }
    }

}

