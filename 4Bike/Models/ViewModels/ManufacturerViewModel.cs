using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _4Bike.Models.ViewModels
{
    [Display(Name = "Manufacturer Name")]
    public class ManufacturerViewModel
    {
        public string Name { get; set; }


    }
}
