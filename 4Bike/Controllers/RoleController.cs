using _4Bike.Areas.Identity.Data;
using _4Bike.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using _4Bike.Data;
using _4Bike.Services;
using _4Bike.Models.Products;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

namespace _4Bike.Controllers
{
    
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AuthDbContext _context;
        private readonly OrderService orderService;

        public RoleController(AuthDbContext authDbContext, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IWebHostEnvironment environment)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = authDbContext;
            orderService = new OrderService(_context, userManager, signInManager, environment); ;
        }

        public IActionResult Index()
        {
            return View(_roleManager.Roles);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult UserList()
        {
            List<UserViewModel> users =_userManager.Users.Select(a => new UserViewModel() { User = a }).ToList();
            var orders = orderService.ListOrderDate();
            foreach (var user in users)
            {
                user.HasOrder = orders.Any(x => x.UserName == user.User.UserName);
                /*foreach(var order in orders)
                {
                    if (user.User.UserName == order.UserName) { 
                        user.HasOrder = true;
                        Console.WriteLine(user.User.UserName  + " Hs Order");
                    }
                } */
            }

            return View(users);
        }

        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(_userManager.GetUserId(User));
            if(id != null) {
                user = await _userManager.FindByIdAsync(id);
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(string id, EditUserViewModel viewModel)
        {
            ApplicationUser targetUser = await _userManager.FindByIdAsync(id);
            if (id == null)
            {
                targetUser = await _userManager.FindByIdAsync(_userManager.GetUserId(User));
            }
            if (ModelState.IsValid)
            {
                targetUser.Email = viewModel.Email;
                targetUser.FirstName = viewModel.FirstName;
                targetUser.LastName = viewModel.LastName;
                targetUser.Address = viewModel.Address;

                await _userManager.UpdateAsync(targetUser);

                if(targetUser != null && id != null)
                {
                    return RedirectToAction(nameof(UserList), "Role");
                }
                else
                {
                    return View(targetUser);
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


            //Remove user's roles to prevent multiple/duplicate roles
            var rolesToRemove = await _userManager.GetRolesAsync(_user);
            await _userManager.RemoveFromRolesAsync(_user, rolesToRemove.ToArray());

            //Add new role to user
            IdentityResult result = await _userManager.AddToRoleAsync(_user, role);

            if (ModelState.IsValid)
            {
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("Error", "Something went wrong, try again.");

            }

            return View();
        }

        /* [Authorize(Roles = "Admin")]
         public IActionResult DeletePerson(int id)
         {

             var personToDelete = _userManager.Users.FindByIdAsync(id);
             _userManager.Users.Remove(personToDelete);
             _userManager.SaveChanges();

             return View(_userManager.Users.ToList());
         }*/

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            var userToRemove = await _userManager.FindByIdAsync(id);
            if (userToRemove == null)
            {
                ViewBag.ErrorMessage = $"User with Id =  {id} can not be found";
                return View(NotFound());
            }
            else
            {
                orderService.RemoveOrderByUserId(id);
                var result = await _userManager.DeleteAsync(userToRemove);
                if (result.Succeeded)
                {
                    return RedirectToAction("UserList");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View("UserList");
            }

        }

        

    }


    }

