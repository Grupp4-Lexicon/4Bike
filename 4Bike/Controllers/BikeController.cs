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
using Microsoft.EntityFrameworkCore;

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
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;

            string path = Path.Combine(this.Environment.WebRootPath, "BikePics");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (ModelState.IsValid)
            {

                Product_Manufacturer manufacturerID = _context.Manufacturers.FirstOrDefault(a => a.ManufacturerID == bike.ManufacturerID);
                

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
                    Manufacturer = manufacturerID
                };

                _context.Bikes.Add(bikeProduct);
                _context.SaveChanges();

                
            }
            return RedirectToAction("ListBikes");
        }

        public IActionResult EditBike(int id)
        {
            var bikeToEdit = _context.Bikes.Where(a => a.BikeID == id).Include(a => a.Manufacturer).FirstOrDefault();
            List<Product_Manufacturer> manufacturerList = _context.Manufacturers.ToList();


            
            ViewBag.Manufactures = manufacturerList.Select(a => new ManufacturerViewModel { ManufacturerID = a.ManufacturerID }).ToList();
           
            _context.Bikes.Where(a => a.BikeID == id).FirstOrDefault();

            return View(bikeToEdit);

        }

        [HttpPost]
        public IActionResult EditBike(Product_Bike eBike)
        {
            _context.Bikes.Update(eBike);
            _context.SaveChanges();
            return RedirectToAction("ListBikes");
        }

        public IActionResult DeleteBike(int id)
        {

            var bikeToDelete = _context.Bikes.Find(id);
            _context.Bikes.Remove(bikeToDelete);
            _context.SaveChanges();

            return RedirectToAction("ListBikes");
        }

    }
}
