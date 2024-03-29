using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.CustomAttribute;

namespace Hotel_Booking.ViewModels
{
    public class Registration
    {
        [Required]
        [MaxLength(100, ErrorMessage = "You can't make name more than 100 characters")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "You can't make name more than 100 characters")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [UniqueEmail]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Two passwords are different!")]
        public string ConfirmPassword { get; set; }
        // [DisplayName("Image")]
        // public IFormFile? File { get; set; }
    }
}