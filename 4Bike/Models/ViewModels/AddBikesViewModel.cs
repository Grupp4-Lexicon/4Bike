using Microsoft.AspNetCore.Http;

namespace _4Bike.Models.ViewModels
{
    public class AddBikesViewModel
    {
        public int BikeID { get; set; }

        public string BikeName { get; set; }
        public int Price { get; set; }
        public string PicPath { get; set; }
        public IFormFile PicFile { get; set; }
        public int ManufacturerID { get; set; }

        public string ManufacturerName { get; set; }
        


    }
}
