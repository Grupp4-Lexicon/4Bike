using _4Bike.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _4Bike.Models.Products;
using _4Bike.Models.ViewModels;


namespace _4Bike.Controllers
{
    public class BikeController : Controller
    {
        private readonly AuthDbContext _context;
        private IWebHostEnvironment Environment;

        public BikeController(AuthDbContext context, IWebHostEnvironment _environment)
        {
            Environment = _environment;
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

        public IActionResult AddBike()
        {
            ViewBag.Bikes = _context.Bikes.ToList();
            ViewBag.Manufacturers = _context.Manufacturers.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddBike(AddBikesViewModel bike)
        {
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;

            string path = Path.Combine(this.Environment.WebRootPath, "BikePics");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(bike.PicFile.FileName);
                string extension = Path.GetExtension(bike.PicFile.FileName);

                fileName = fileName + DateTime.Now.ToString("yy-hh-mm-ss-fff") + extension;

                string filePath = Path.Combine(path, fileName);

                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    bike.PicFile.CopyTo(stream);
                }

                Product_Manufacturer manufacturer = _context.Manufacturers.FirstOrDefault(k => k.ManufacturerID == bike.ManufacturerID);
                Product_Bike bikeProduct = new Product_Bike
                {
                    BikeName = bike.BikeName,
                    BikePrice = bike.Price,
                    BikePicNav = filePath,
                    ManufacturerID = 1
                };

                _context.Bikes.Add(bikeProduct);
                _context.SaveChanges();

                Product_Bike insertedBike = _context.Bikes.FirstOrDefault(a => a.BikeName == bikeProduct.BikeName);
            }
            return RedirectToAction("ListBikes");
        }
    }
}
