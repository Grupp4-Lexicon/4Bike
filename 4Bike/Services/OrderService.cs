using _4Bike.Areas.Identity.Data;
using _4Bike.Data;
using _4Bike.Models.Products;
using _4Bike.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace _4Bike.Services
{
    public class OrderService
    {
        // Containes functions for working with Orders
        private readonly AuthDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private IWebHostEnvironment Environment;
        public static CookieOptions cookie = new CookieOptions();

        public OrderService(AuthDbContext authDbContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IWebHostEnvironment _environment)
        {
            Environment = _environment;
            _context = authDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public void AddOrder(ClaimsPrincipal user, List<int> shopArr)
        {
                Product_Order order = new Product_Order() { OrderDate = DateTime.Now, OrderHandelCost = 11, Id = _userManager.GetUserId(user) };
                _context.Orders.Add(order);
                _context.SaveChanges();

                foreach (int id in shopArr.Distinct().ToList())
                {
                    int count = shopArr.Count(x => x == id);

                    Product_BikeOrder pb = new Product_BikeOrder() { BikeOrderOrderID = order.OrderID, BikeOrderBikeID = id, BikeOrderQuantity = count };
                    _context.BikeOrders.Add(pb);
                }
                _context.SaveChanges();
        }

        public List<OrderView> SearchOrder(OrderView input)
        {
            List<OrderView> listToSearch = ListOrder();
            List<OrderView> searchResult = new List<OrderView>();

            foreach(var item in listToSearch)
            {
                if(listToSearch.Any(item => item.BikeName == input.BikeName || item.OrderDate == input.OrderDate))
                {
                    searchResult.Add(item);
                }
            }

            return searchResult;
        }

        public List<OrderView> ListOrder()
        {
            List<OrderView> ordView = (from o in _context.Orders.ToList()
                                       join bo in _context.BikeOrders.ToList() on o.OrderID equals bo.BikeOrderOrderID
                                       join b in _context.Bikes.ToList() on bo.BikeOrderBikeID equals b.BikeID
                                       join u in _context.Users.ToList() on o.Id equals u.Id
                                       where o.OrderID == 4
                                       select new OrderView { BikeName = b.BikeName, Quantity = bo.BikeOrderQuantity, OrderDate = o.OrderDate, Price = b.BikePrice }).ToList();
            return ordView;
        }

        public List<OrderView> ListOrderDate()
        {
            List<OrderView> ordView = (from o in _context.Orders.ToList()
                                       join bo in _context.BikeOrders.ToList() on o.OrderID equals bo.BikeOrderOrderID
                                       join b in _context.Bikes.ToList() on bo.BikeOrderBikeID equals b.BikeID
                                       join u in _context.Users.ToList() on o.Id equals u.Id
                                       join m in _context.Manufacturers.ToList() on b.ManufacturerID equals m.ManufacturerID
                                       orderby o.OrderDate descending
                                       select new OrderView {UserName = u.UserName, BikeId = bo.BikeOrderBikeID, BikeOrderId = bo.BikeOrderID, OrderId = o.OrderID, ManifacturerName = m.ManufacturerName, BikeName = b.BikeName, Quantity = bo.BikeOrderQuantity, OrderDate = o.OrderDate, Price = b.BikePrice, PicPath = b.BikePicNav, TotalCost = bo.BikeOrderQuantity * b.BikePrice }).ToList();
            return ordView;
        }

        public void RemoveOrder(int orderID)
        {
            _context.Orders.Remove(_context.Orders.Find(orderID));
            _context.SaveChanges();
        }

        public void RemoveOrderByUserId(string userId) {
            _context.Orders.RemoveRange(_context.Orders.Where(a => a.ApplicationUser.Id == userId));
            _context.SaveChanges();
        }

        public void RemoveOrder(Product_BikeOrder bikeOrder)
        {
            _context.BikeOrders.Update(bikeOrder);
            _context.SaveChanges();
        }

        public bool OrderReceipt(int orderId)
        {
            //Checks to see if the directory exsists and if not creates the save directory for the receipts
            const string saveDir = "Receipts";
            string path = Path.Combine(Environment.WebRootPath, saveDir);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<OrderView> orderHistory = ListOrderDate();
            OrderView currentOrder = new OrderView { OrderId = orderId };

            string receiptName = currentOrder.OrderId.ToString() + "-" + DateTime.Now.ToString("yy-MM-dd-hh-mm-fff") + ".txt";
            string textToAdd;
            List<string> receiptBody = new List<string>();

            foreach( var ite in orderHistory.Select(x => x.OrderId).Distinct())
            {
                foreach (var item in orderHistory.Where(x => x.OrderId == ite))
                {
                    textToAdd = ("-----------------------------------\n" +
                                 $"OrderId: {item.OrderId}\n" +
                                 $"Orederd Item: {item.BikeName}\n" +
                                 $"Ordered Quantity: {item.Quantity} \n" +
                                 $"Oredred Item Price: {item.Price} \n" +
                                 $"Order Total Price: {item.TotalCost}\n" +
                                 $"Orederd Date: {item.OrderDate}\n" +
                                 "-----------------------------------");
                    receiptBody.Add(textToAdd);
                }
            }

            try
            {
                File.WriteAllLines((Path.Combine(path, receiptName)), receiptBody);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
