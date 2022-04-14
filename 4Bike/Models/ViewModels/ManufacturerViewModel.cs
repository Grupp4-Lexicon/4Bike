using System.ComponentModel.DataAnnotations;

namespace _4Bike.Models.ViewModels
{
    [Display(Name = "Manufacturer Name")]
    public class ManufacturerViewModel
    {
        public string Name { get; set; }
        public int ManufacturerID { get; set;  }

    }
}
