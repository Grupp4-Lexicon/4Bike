using _4Bike.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using _4Bike.Models.Products;
using _4Bike.Models.ViewModels;

namespace _4Bike.Controllers
{
    public class ManufacturerController : Controller
    {
        public readonly AuthDbContext _context;

        public ManufacturerController(AuthDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Manufacturers.Select(a => new ManufacturerViewModel { Name = a.ManufacturerName }).ToList());
        }

        public IActionResult AddManufacturer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddManufacturer(ManufacturerViewModel manufacturerVM)
        {
            if (ModelState.IsValid)
            {
                _context.Manufacturers.Add(new Product_Manufacturer() { ManufacturerName = manufacturerVM.Name });
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }







    }
}

