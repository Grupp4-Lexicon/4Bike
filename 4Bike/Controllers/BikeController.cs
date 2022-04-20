using _4Bike.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using _4Bike.Models.Products;
using _4Bike.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "Admin")]
        public IActionResult ListBikes()
        {

            var bikesInfo = _context.Bikes.
                Include(a => a.Manufacturer)             
                .ToList();

            return View(bikesInfo);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult AddBike()
        {
            ViewBag.Bikes = _context.Bikes.ToList();
            ViewBag.Manufacturers = _context.Manufacturers.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult SertchBike(string sertchBike)
        {
            
            if (_context.Bikes.Any(x => x.BikeName.StartsWith(sertchBike))) {
                sertchBike = sertchBike.ToLower();
                List<AddBikesViewModel> bik = (from b in _context.Bikes.ToList()
                                               join m in _context.Manufacturers.ToList() on b.ManufacturerID equals m.ManufacturerID
                                               where b.BikeName.ToLower().StartsWith(sertchBike)
                                               select new AddBikesViewModel {BikeID =b.BikeID, BikeName = b.BikeName, ManufacturerID = m.ManufacturerID, Price = b.BikePrice, ManufacturerName = m.ManufacturerName, PicPath = b.BikePicNav }).ToList();
                return PartialView("BikeSertch", bik);
            }else if (_context.Manufacturers.Any(x => x.ManufacturerName.StartsWith(sertchBike)))
            {
                sertchBike = sertchBike.ToLower();
                List<AddBikesViewModel> bik = (from b in _context.Bikes.ToList()
                                               join m in _context.Manufacturers.ToList() on b.ManufacturerID equals m.ManufacturerID
                                               where m.ManufacturerName.ToLower().StartsWith(sertchBike)
                                               select new AddBikesViewModel {BikeID=b.BikeID, BikeName = b.BikeName, ManufacturerID = m.ManufacturerID, Price = b.BikePrice, ManufacturerName = m.ManufacturerName, PicPath = b.BikePicNav }).ToList();
                return PartialView("BikeSertch", bik);
            }
            else
            {
                List<AddBikesViewModel> bik = new List<AddBikesViewModel>();
                return PartialView("BikeSertch", bik);
            }

        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddBike(AddBikesViewModel bike)
        {
            const string folderToSave = "BikePics";

            string path = Path.Combine(Environment.WebRootPath, folderToSave);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (ModelState.IsValid)
            {
                Product_Manufacturer manufacturerID = _context.Manufacturers.FirstOrDefault(a => a.ManufacturerID == bike.ManufacturerID);

                string fileName = Path.GetFileNameWithoutExtension(bike.PicFile.FileName) +
                                  DateTime.Now.ToString("yy-hh-mm-ss-fff") +
                                  Path.GetExtension(bike.PicFile.FileName);

                string filePath = Path.Combine(path, fileName);
                string filePathForDB = Path.Combine(folderToSave, fileName);
              

    
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    bike.PicFile.CopyTo(stream);
                }

                Product_Manufacturer manufacturer = _context.Manufacturers.FirstOrDefault(k => k.ManufacturerID == bike.ManufacturerID);

                Product_Bike bikeProduct = new Product_Bike
                {
                    BikeName = bike.BikeName,
                    BikePrice = bike.Price,
                    BikePicNav = filePathForDB,
                    Manufacturer = manufacturerID
                };

                _context.Bikes.Add(bikeProduct);
                _context.SaveChanges();
            }

            return RedirectToAction("ListBikes");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult EditBike(int id)
        {
           
            List<Product_Manufacturer> manufacturerList = _context.Manufacturers.ToList();

            AddBikesViewModel bik = (from b in _context.Bikes.ToList()
                                           join m in _context.Manufacturers.ToList() on b.ManufacturerID equals m.ManufacturerID
                                           where b.BikeID == id
                                           select new AddBikesViewModel { BikeID = b.BikeID, BikeName = b.BikeName, ManufacturerID = m.ManufacturerID, Price = b.BikePrice, ManufacturerName = m.ManufacturerName, PicPath = b.BikePicNav }).SingleOrDefault(); ;


            ViewBag.Manufactures = manufacturerList.Select(a => new ManufacturerViewModel { ManufacturerID = a.ManufacturerID , Name = a.ManufacturerName}).ToList();
           
            _context.Bikes.Where(a => a.BikeID == id).FirstOrDefault();

            return View(bik);

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditBike(AddBikesViewModel eBike)
        {
            const string folderToSave = "BikePics";
            string filePathForDB = eBike.PicPath;

            string path = Path.Combine(Environment.WebRootPath, folderToSave);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (eBike.PicFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(eBike.PicFile.FileName) +
                                      DateTime.Now.ToString("yy-hh-mm-ss-fff") +
                                      Path.GetExtension(eBike.PicFile.FileName);

                string filePath = Path.Combine(path, fileName);
                filePathForDB = Path.Combine(folderToSave, fileName);

                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    eBike.PicFile.CopyTo(stream);
                }

            }
            Product_Bike bikeProduct = new Product_Bike
            {
                BikeID = eBike.BikeID,
                BikeName = eBike.BikeName,
                BikePrice = eBike.Price,
                BikePicNav = filePathForDB,
                ManufacturerID = eBike.ManufacturerID
            };
            _context.Bikes.Update(bikeProduct);
            _context.SaveChanges();
            return RedirectToAction("ListBikes");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteBike(int id)
        {

            var bikeToDelete = _context.Bikes.Find(id);
            _context.Bikes.Remove(bikeToDelete);
            _context.SaveChanges();

            return RedirectToAction("ListBikes");
        }

        public IActionResult ChosenBike(int bID)
        {
            var chosenBike = _context.Bikes.Where(a => a.BikeID == bID).Include(a => a.Manufacturer).FirstOrDefault();
            List<Product_Manufacturer> manufacturerList = _context.Manufacturers.ToList();

            ViewBag.Manufactures = manufacturerList.Select(a => new ManufacturerViewModel { ManufacturerID = a.ManufacturerID }).ToList();

            _context.Bikes.Where(a => a.BikeID == bID).FirstOrDefault();

            return View(chosenBike);

        }
    }
}
