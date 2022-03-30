using _4Bike.Models;
using _4Bike.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using _4Bike.Models.ViewModels;
using _4Bike.Models.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using _4Bike.Areas.Identity.Data;
using System.Text.Json;
using _4Bike.Services;

namespace _4Bike.Controllers
{
    public class HomeController : Controller
    {
        private readonly OrderService orderService;
        private readonly AuthDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public static CookieOptions cookie = new CookieOptions();

        public HomeController(AuthDbContext authDbContext, UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            _context = authDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            orderService = new OrderService(authDbContext, userManager, signInManager);
        }

        public IActionResult Index()
        {
            List<ShopingcartView> bikes = new List<ShopingcartView>();
            
            if (Request.Cookies["ShopingId"] != null)
            {
                List<int> sArr = JsonSerializer.Deserialize<List<string>>(Request.Cookies["ShopingId"]).Select(int.Parse).ToList();
                foreach (int id in sArr.Distinct().ToList())
                {
                    
                    int count = sArr.Count(x => x == id);
                    ShopingcartView shopingcart = (from b in _context.Bikes.ToList()
                                        join m in _context.Manufacturers.ToList() on b.ManufacturerID equals m.ManufacturerID
                                        where b.BikeID == id
                                        select new ShopingcartView{ BikeName = b.BikeName, ManufacturerID = m.ManufacturerID, Price = b.BikePrice, ManufacturerName = m.ManufacturerName, Quantity=count, PicPath = b.BikePicNav, TotalPrice = count*b.BikePrice}).SingleOrDefault();
                    bikes.Add(shopingcart);
                }
            }
            return View(bikes);
        }

        [HttpPost]
        public void AddToShopingKart(int bID)
        {
            List<string> sId = new List<string>();
            if (Request.Cookies["ShopingId"] != null)
            {
                sId = JsonSerializer.Deserialize<List<string>>(Request.Cookies["ShopingId"]);                
            }
            sId.Add(bID.ToString());
            cookie.Expires = DateTime.Now.AddMinutes(2);
            Response.Cookies.Append("ShopingId", JsonSerializer.Serialize(sId), cookie);
        }

        [HttpPost]
        public void RemoveFromShopingKart(int bID)
        {
            List<string> sArr = JsonSerializer.Deserialize<List<string>>(Request.Cookies["ShopingId"]);
            //Request.Cookies["ShopingId"];
            sArr.Remove(bID.ToString());
                Response.Cookies.Append("ShopingId", JsonSerializer.Serialize(sArr), cookie);
        }

        [HttpPost]
        public IActionResult AddOrder()
        {
            if (_signInManager.IsSignedIn(HttpContext.User) && Request.Cookies["ShopingId"] != null)
            {
                List<int> sArr = JsonSerializer.Deserialize<List<string>>(Request.Cookies["ShopingId"]).Select(int.Parse).ToList();
                orderService.AddOrder(HttpContext.User, sArr);
                Response.Cookies.Delete("ShopingId");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveOrder(int orderID)
        {
            orderService.RemoveOrder(orderID);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveOrder(Product_BikeOrder bikeOrder)
        {
            orderService.RemoveOrder(bikeOrder);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
