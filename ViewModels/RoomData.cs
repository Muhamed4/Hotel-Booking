using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.CustomAttribute;
using Hotel_Booking.Data;
using Hotel_Booking.Repository.RoomsRepo;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using NuGet.Protocol.Plugins;

namespace Hotel_Booking.ViewModels
{
    public class RoomData
    {
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price Must be >= 0")]
        public decimal Price { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "RoomNumber Must be >= 1")]
        [UniqueRoomNumber]
        public int RoomNumber { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "BedCount Must be >= 1")]
        public int BedCount { get; set; }
        [Required]
        [DisplayName("Choose the gallery images of this room")]
        public IFormFileCollection GalleryImages { get; set; }
        public int hotelID { get; set; }
        public bool addMore { get; set; }
    }
}