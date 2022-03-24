using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName("Upload Image")]
        public string BikePicNav { get; set; }

        public int ManufacturerID { get; set; }
       
        public Product_Manufacturer Manufacturer { get; set; }

        public ICollection<Product_BikeOrder> Orders { get; set; }

    }
}
