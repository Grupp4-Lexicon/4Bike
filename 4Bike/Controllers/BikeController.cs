using _4Bike.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _4Bike.Models.Products;
using _4Bike.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace _4Bike.Controllers
{
    public class BikeController : Controller
    {
        private readonly AuthDbContext _context;

        public BikeController(AuthDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListBikes()
        {
            var bikesInfo = _context.Bikes.
                Include(a => a.Manufacturer)
                .ToList();

            return View(bikesInfo);
        }

        public IActionResult AddBike()
        {
            ViewBag.Bikes = _context.Bikes.ToList();
            ViewBag.Manufacturers = _context.Manufacturers.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddBike(AddBikesViewModel bike)
        {
            if (ModelState.IsValid)
            {
                Product_Manufacturer manufacturerID = _context.Manufacturers.FirstOrDefault(a => a.ManufacturerID == bike.ManufacturerID);
                
                Product_Bike bikeProduct = new Product_Bike
                {
                    BikeName = bike.BikeName,
                    BikePrice = bike.Price,
                    BikePicNav = bike.Pic,
                    Manufacturer = manufacturerID
                   
                };

                _context.Bikes.Add(bikeProduct);
                _context.SaveChanges();

                
            }
            return RedirectToAction("ListBikes");
        }
    }
}
