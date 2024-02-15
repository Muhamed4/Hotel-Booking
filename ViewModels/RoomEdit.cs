using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.CustomAttribute;

namespace Hotel_Booking.ViewModels
{
    public class RoomEdit
    {
        public int RoomID { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price Must be >= 0")]
        [DisplayName("Price per night $")]
        public decimal Price { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Room Number Must be >= 1")]
        [AdminUniqueRoomNumber]
        [DisplayName("Room Number")]
        public int RoomNumber { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Number of Beds Must be >= 1")]
        [DisplayName("Number of Beds per room")]
        public int BedCount { get; set; }
        // [Required(ErrorMessage = "People would like to see the room.")]
        [DisplayName("Choose the gallery images of this room")]
        public IFormFileCollection? GalleryImages { get; set; }
        public int hotelID { get; set; }
        public List<string>? Images { get; set; }
    }
}