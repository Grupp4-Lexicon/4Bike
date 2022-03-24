using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _4Bike.Models.ViewModels
{
    public class EditUserViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(100, MinimumLength = 1)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First name")]
        [StringLength(100, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [StringLength(100, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Address")]
        [StringLength(100, MinimumLength = 1)]
        public string Address { get; set; }

        public EditUserViewModel() { }

        public EditUserViewModel(string email, string fName, string lName, string address)
        {
            Email = email;
            FirstName = fName;
            LastName = lName;
            Address = address;
        }
    }
}
