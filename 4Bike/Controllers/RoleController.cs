using _4Bike.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4Bike.Controllers
{
    public class RoleController : Controller
    {
        //private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly UserManager<ApplicationUser> _userManager;

        //public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        //{
        //    _roleManager = roleManager;
        //    _userManager = userManager;
        //}

        public IActionResult Index()
        {
            return View();
        }
    }
}
