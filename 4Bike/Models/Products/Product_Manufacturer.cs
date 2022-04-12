using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _4Bike.Models.Products
{
    public class Product_Manufacturer
    {
        [Key]
        public int ManufacturerID { get; set; }
        public string ManufacturerName { get; set; }
        public List<Product_Bike> ManufacturerProducts { get; set; }
    }
}
