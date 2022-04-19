using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _4Bike.Areas.Identity.Data;

namespace _4Bike.Models.Products
{
    public class Product_Order
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderHandelCost { get; set; }
        [ForeignKey("Id")]
        public ApplicationUser ApplicationUser { get; set; }
        public string Id { get; set; }

        public ICollection<Product_BikeOrder> Bikes { get; set; }
        
    }
}
