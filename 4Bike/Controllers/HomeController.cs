using _4Bike.Models;
using _4Bike.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using _4Bike.Models.ViewModels;
using _4Bike.Models.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using _4Bike.Areas.Identity.Data;
using System.Text.Json;
using _4Bike.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace _4Bike.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly OrderService orderService;
        private readonly AuthDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public static CookieOptions cookie = new CookieOptions();

        public HomeController(AuthDbContext authDbContext, UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager, IWebHostEnvironment environment)
        {
            _environment = environment;
            _context = authDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            orderService = new OrderService(authDbContext, userManager, signInManager, environment);
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
                                                   select new ShopingcartView { BikeName = b.BikeName, ManufacturerID = m.ManufacturerID, Price = b.BikePrice, ManufacturerName = m.ManufacturerName, Quantity = count, PicPath = b.BikePicNav, TotalPrice = count * b.BikePrice }).SingleOrDefault();
                    bikes.Add(shopingcart);
                }
            }
            ViewBag.Bikes = _context.Bikes.ToList();
            return View(bikes);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult EditOrder()
        {
            //orderView.OrderList = orderService.ListOrder();

            return View();
        }

        public IActionResult ShopingKart()
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
                                                   select new ShopingcartView {BikeID=b.BikeID, BikeName = b.BikeName, ManufacturerID = m.ManufacturerID, Price = b.BikePrice, ManufacturerName = m.ManufacturerName, Quantity = count, PicPath = b.BikePicNav, TotalPrice = count * b.BikePrice }).SingleOrDefault();
                    bikes.Add(shopingcart);
                }
            }
            if (bikes.Any(a =>a ==null))
            {
                Response.Cookies.Delete("ShopingId");
                bikes.Clear();
            }
            return View(bikes);
        }
        [HttpPost]
        public IActionResult AddToShopingKart(int bID)
        {
            List<string> sId = new List<string>();
            if (Request.Cookies["ShopingId"] != null)
            {
                sId = JsonSerializer.Deserialize<List<string>>(Request.Cookies["ShopingId"]);                
            }
            sId.Add(bID.ToString());
            cookie.Expires = DateTime.Now.AddDays(3);

            Response.Cookies.Append("ShopingId", JsonSerializer.Serialize(sId), cookie);
            return RedirectToAction("ShopingKart");
        }
        [HttpGet]
        public IActionResult RemoveFromShopingKart(int bID)
        {
            List<string> sArr = JsonSerializer.Deserialize<List<string>>(Request.Cookies["ShopingId"]);
            //Request.Cookies["ShopingId"];
            sArr.Remove(bID.ToString());          
                
            Response.Cookies.Append("ShopingId", JsonSerializer.Serialize(sArr), cookie);
            return RedirectToAction("ShopingKart");

        }

        [HttpGet]
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
        [Authorize(Roles = "Admin")]
        public IActionResult RemoveOrder(int orderID)
        {
            orderService.RemoveOrder(orderID);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult RemoveBikeOrder(int boId)
        {
            _context.BikeOrders.Remove(_context.BikeOrders.Find(boId));
            _context.SaveChanges();
            foreach (var item in _context.Orders.ToList())
            {
                if(!_context.BikeOrders.Any(x => x.BikeOrderOrderID == item.OrderID))
                {
                    _context.Orders.Remove(item);
                    _context.SaveChanges();
                }
            }
            
            return PartialView("ViewOrder", orderService.ListOrderDate());
        }  
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult ViewOrder(string userName,DateTime orderDate)
        {          
            
            if (orderService.ListOrderDate().Any(x => x.OrderDate.Date == orderDate) && userName != null)
            {                
                return PartialView(orderService.ListOrderDate().Where(x => x.OrderDate.Date==orderDate && x.UserName.StartsWith(userName)));

            }else if(orderService.ListOrderDate().Any(x => x.OrderDate.Date == orderDate))
            {
                
                return PartialView("ViewOrder",orderService.ListOrderDate().Where(x => x.OrderDate.Date == orderDate ));

            }
            else if(userName != null)
            {
                return PartialView("ViewOrder", orderService.ListOrderDate().Where(x => x.UserName.StartsWith(userName)));
            }
            else { 
                return PartialView("ViewOrder", orderService.ListOrderDate());
            }
            
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateOrder(Product_BikeOrder bikeOrder)
        {     
            _context.BikeOrders.Update(bikeOrder);
            _context.SaveChanges();

            return PartialView("ViewOrder", orderService.ListOrderDate());
        }
        public IActionResult OrderingHistory()
        {
            List<OrderView> ordView = (from o in _context.Orders.ToList()
                                       join bo in _context.BikeOrders.ToList() on o.OrderID equals bo.BikeOrderOrderID
                                       join b in _context.Bikes.ToList() on bo.BikeOrderBikeID equals b.BikeID
                                       join m in _context.Manufacturers.ToList() on b.ManufacturerID equals m.ManufacturerID
                                       where o.Id == _userManager.GetUserId(HttpContext.User)
                                       orderby o.OrderDate descending
                                       select new OrderView { OrderId = o.OrderID, ManifacturerName = m.ManufacturerName, BikeName = b.BikeName, Quantity = bo.BikeOrderQuantity, OrderDate = o.OrderDate, Price = b.BikePrice, PicPath = b.BikePicNav, TotalCost =bo.BikeOrderQuantity * b.BikePrice  }).ToList();
            return View(ordView);
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

        public IActionResult MakeReceipt(int orderId)
        {
            orderService.OrderReceipt(orderId);

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
