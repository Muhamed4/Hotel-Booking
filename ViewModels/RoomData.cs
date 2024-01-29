using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.CustomAttribute;
using Hotel_Booking.Data;
using Hotel_Booking.Repository.RoomsRepo;

namespace Hotel_Booking.ViewModels
{
    public class RoomData
    {
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        [UniqueRoomNumber]
        public int RoomNumber { get; set; }

        public int BedCount { get; set; }
        public int hotelID { get; set; }
    }
}