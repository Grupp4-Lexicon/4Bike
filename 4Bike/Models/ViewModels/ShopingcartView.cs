using Microsoft.AspNetCore.Http;

namespace _4Bike.Models.ViewModels
{
    public class ShopingcartView
    {
        public int BikeID { get; set; }
        public string BikeName { get; set; }
        public int Price { get; set; }
        public string PicPath { get; set; }
        public IFormFile PicFile { get; set; }
        public int ManufacturerID { get; set; }

        public string ManufacturerName { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }



    }
}
