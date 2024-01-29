using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Data;
using Hotel_Booking.Models;

namespace Hotel_Booking.Repository.RoomImageRepo
{
    public class RoomImageRepo : IRoomImageRepo
    {
        private readonly AppDbContext _context;
        public RoomImageRepo(AppDbContext context)
        {
            this._context = context;
        }
        public void Insert(RoomImage roomImage)
        {
            _context.RoomImages.Add(roomImage);
            _context.SaveChanges();
        }
    }
}