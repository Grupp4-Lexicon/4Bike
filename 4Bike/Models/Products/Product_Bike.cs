using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _4Bike.Models.Products
{
    public class Product_Bike
    {
        [Key]
        public int BikeID { get; set; }

        public int BikePrice { get; set; }

        public string BikeName { get; set; }


        public int ManufacturerID { get; set; }
        public Product_Manufacturer Manufacturer { get; set; }

    }
}
