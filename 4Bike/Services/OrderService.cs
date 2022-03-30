using _4Bike.Areas.Identity.Data;
using _4Bike.Data;
using _4Bike.Models.Products;
using _4Bike.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace _4Bike.Services
{
    public class OrderService
    {
        // Containes functions for working with Orders
        private readonly AuthDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public static CookieOptions cookie = new CookieOptions();

        public OrderService(AuthDbContext authDbContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
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

        public void RemoveOrder(int orderID)
        {
            _context.Orders.Remove(_context.Orders.Find(orderID));
            _context.SaveChanges();
        }

        public void RemoveOrder(Product_BikeOrder bikeOrder)
        {
            _context.BikeOrders.Update(bikeOrder);
            _context.SaveChanges();
        }
    }
}
