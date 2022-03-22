using _4Bike.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _4Bike.Models.Products;
using _4Bike.Models.ViewModel;


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
            var bikesInfo = _context.Bikes.ToList();

            return View(bikesInfo);
                
        }

        public IActionResult AddPerson()
        {
            ViewBag.Bikes = _context.Bikes.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddPerson(AddBikesViewModel bike)
        {
            if (ModelState.IsValid)
            {
                Product_Bike bikeProduct = new Product_Bike
                {
                    BikeName = bike.BikeName,
                    BikePrice = bike.Price,
                    BikePicNav = bike.Pic,
                   
                    
                };

                _context.Bikes.Add(bikeProduct);
                _context.SaveChanges();

                Product_Bike insertedBike =_context.Bikes.FirstOrDefault(a => a.BikeName == bikeProduct.BikeName);
                
            }

            return RedirectToAction("ListBikes");
        }
    }
}
