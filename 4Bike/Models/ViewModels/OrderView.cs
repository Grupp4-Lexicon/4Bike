﻿using System;

namespace _4Bike.Models.ViewModels
{
    public class OrderView
    {
        public string BikeName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int TotalCost { get; set; }
        public DateTime OrderDate { get; set; }



    }
}
