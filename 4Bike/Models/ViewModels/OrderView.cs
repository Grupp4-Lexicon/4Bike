using System;
using System.Collections.Generic;
﻿using Microsoft.AspNetCore.Http;


namespace _4Bike.Models.ViewModels
{
    public class OrderView
    {
        public int OrderId { get; set; }
        public int BikeOrderId { get; set; }
        public int BikeId { get; set; }
        public string BikeName { get; set; }
        public string UserName { get; set; }
        public string ManifacturerName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int TotalCost { get; set; }
        public DateTime OrderDate { get; set; }


        public List<OrderView> OrderList = new List<OrderView>();

        public string PicPath { get; set; }
        public IFormFile PicFile { get; set; }


    }
}
