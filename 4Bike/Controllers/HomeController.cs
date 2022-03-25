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

namespace _4Bike.Controllers
{
    public class HomeController : Controller
    {
        private readonly  AuthDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public static CookieOptions cookie = new CookieOptions();

        public HomeController(AuthDbContext authDbContext, UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            _context = authDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
           
            List<OrderView> ordView =( from o in _context.Orders.ToList()
                    join bo in _context.BikeOrders.ToList() on o.OrderID equals bo.BikeOrderOrderID
                    join b in _context.Bikes.ToList() on bo.BikeOrderBikeID equals b.BikeID
                          join u in _context.Users.ToList() on o.Id equals u.Id
                          where o.OrderID==4
                          select new OrderView {BikeName = b.BikeName, Quantity = bo.BikeOrderQuantity, OrderDate = o.OrderDate, Price = b.BikePrice }).ToList();

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
            string sId = bID.ToString();
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

                Product_Order order = new Product_Order() { OrderDate = DateTime.Now, OrderHandelCost = 11, Id = _userManager.GetUserId(HttpContext.User) };
                _context.Orders.Add(order);
                _context.SaveChanges();

                List<int> sArr = JsonSerializer.Deserialize<List<string>>(Request.Cookies["ShopingId"]).Select(int.Parse).ToList();

                foreach (int id in sArr.Distinct().ToList()) {
                    int count = sArr.Count(x => x == id);

                    Product_BikeOrder pb = new Product_BikeOrder() { BikeOrderOrderID=order.OrderID, BikeOrderBikeID=id, BikeOrderQuantity=count};
                    _context.BikeOrders.Add(pb);
                }
                _context.SaveChanges();
                Response.Cookies.Delete("ShopingId");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult RemoveOrder(int orderID)
        {
            _context.Orders.Remove(_context.Orders.Find(orderID));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult RemoveOrder(Product_BikeOrder bikeOrder)
        {
            _context.BikeOrders.Update(bikeOrder);
            _context.SaveChanges();
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
