using _4Bike.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4Bike.Models.ViewModels
{
    public class UserViewModel
    {
        public ApplicationUser User;
        public bool HasOrder;
    }
}
