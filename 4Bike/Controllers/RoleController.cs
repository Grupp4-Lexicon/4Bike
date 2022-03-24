using _4Bike.Areas.Identity.Data;
using _4Bike.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4Bike.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_roleManager.Roles);
        }

        public IActionResult UserList()
        {
            return View(_userManager.Users.ToList());
        }

        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(string id, EditUserViewModel viewModel)
        {
            ApplicationUser targetUser = await _userManager.FindByIdAsync(id);

            if (ModelState.IsValid)
            {
                targetUser.Email = viewModel.Email;
                targetUser.FirstName = viewModel.FirstName;
                targetUser.LastName = viewModel.LastName;
                targetUser.Address = viewModel.Address;

                await _userManager.UpdateAsync(targetUser);

                if(targetUser != null)
                {
                    return RedirectToAction(nameof(UserList), "Role");
                }

                ModelState.AddModelError("Storage", "Failed to save user information");

            }

            return View();

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public IActionResult AddUserToRole()
        {
            ViewData["Roles"] = new SelectList(_roleManager.Roles, "Name", "Name");
            ViewData["Users"] = new SelectList(_userManager.Users, "Id", "UserName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUserToRole(string role, string user)
        {

            ViewData["Roles"] = new SelectList(_roleManager.Roles, "Name", "Name");
            ViewData["Users"] = new SelectList(_userManager.Users, "Id", "UserName");

            var _user = await _userManager.FindByIdAsync(user);
            IdentityResult result = await _userManager.AddToRoleAsync(_user, role);

            if (ModelState.IsValid)
            {
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");

                }

                ModelState.AddModelError("duplicate_entry", "User already has that role!");

            }

            return View();
        }


    }
}
