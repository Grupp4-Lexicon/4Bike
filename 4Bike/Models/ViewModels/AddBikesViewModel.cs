using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4Bike.Models.ViewModels
{
    public class AddBikesViewModel
    {
        public string BikeName { get; set; }
        public int Price { get; set; }
        public string PicPath { get; set; }
        public IFormFile PicFile { get; set; }
        public int ManufacturerID { get; set; }

        public string ManufacturerName { get; set; }
        


    }
}
