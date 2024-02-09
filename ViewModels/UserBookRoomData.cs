using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.ViewModels
{
    public class UserBookRoomData
    {
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string UserId { get; set; }
        public int RoomId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Number of Nights Must be >= 1")]
        public int Nights { get; set; }
        [DisplayName("Date")]
        public DateTime BookDate { get; set; }
    }
}