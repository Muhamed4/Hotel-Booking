using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Data;
using Hotel_Booking.Models;

namespace Hotel_Booking.Repository.AdminRepo
{
    public class AdminRepo : IAdminRepo
    {
        private readonly AppDbContext _context;
        public AdminRepo(AppDbContext context)
        {
            this._context = context;
        }

        public List<Hotel> GetHotels()
        {
            return _context.Hotels.ToList();
        }
    }
}