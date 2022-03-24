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

namespace _4Bike.Controllers
{
    public class HomeController : Controller
    {
        private readonly  AuthDbContext _context;
        public static CookieOptions cookie = new CookieOptions();
        public HomeController(AuthDbContext authDbContext)
        {
            _context = authDbContext;
            
        }

        public IActionResult Index()
        {
           List<OrderView> ordView =( from o in _context.Orders.ToList()
                    join bo in _context.BikeOrders.ToList() on o.OrderID equals bo.BikeOrderOrderID
                    join b in _context.Bikes.ToList() on bo.BikeOrderBikeID equals b.BikeID
                          join u in _context.Users.ToList() on o.Id equals u.Id
                          where o.OrderID==1
                          select new OrderView {BikeName = b.BikeName, Quantity = bo.BikeOrderQuantity, OrderDate = o.OrderDate, Price = b.BikePrice }).ToList();
            
            
            return View(ordView);
        }
        
        public void AddToShopingKart()
        {
                       
            Response.Cookies.Append("ShopingId", "1",cookie);
        }
        [HttpPost]
        public IActionResult AddOrder(Product_Order order)
        {
            if (ModelState.IsValid)
            {
               

                _context.Orders.Add(order);
                _context.SaveChanges();
                /*foreach (item in bikeIDs) {
                    _context.BikeOrders.Add();
                        }*/
                
            }
            return RedirectToAction("ListBikes");
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
