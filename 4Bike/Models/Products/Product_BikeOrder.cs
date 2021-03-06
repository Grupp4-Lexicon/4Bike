using System.ComponentModel.DataAnnotations;

namespace _4Bike.Models.Products
{
    public class Product_BikeOrder
    {
        [Key]
        public int BikeOrderID { get; set; }
        public int BikeOrderQuantity { get; set; }

        public int BikeOrderBikeID { get; set; }
        public Product_Bike BikeOrderBike { get; set; }

        public int BikeOrderOrderID { get; set; }
        public Product_Order BikeOrderOrder { get; set; }
    }
}
