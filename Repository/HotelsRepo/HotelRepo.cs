using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Data;
using Hotel_Booking.Models;

namespace Hotel_Booking.Repository.HotelRepo
{
    public class HotelRepo : IHotelRepo
    {
        private readonly AppDbContext _context;
        public HotelRepo(AppDbContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            var _hotel = GetById(id);

            if(_hotel is not null)
            {
                _context.Hotels.Remove(_hotel);
                _context.SaveChanges();
            }
        }

        public List<Hotel> GetAllHotels()
        {
            return _context.Hotels.ToList();
        }

        public Hotel GetById(int id)
        {
            var _hotel = _context.Hotels.FirstOrDefault(X => X.ID == id);

            return _hotel;
        }

        public void Insert(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
        }

        public void Update(int id, Hotel newHotel)
        {
            var _oldHotel = GetById(id);
            _oldHotel.Name = newHotel.Name;
            _oldHotel.Country = newHotel.Country;
            _oldHotel.City = newHotel.City;
            _oldHotel.Description = newHotel.Description;
            _oldHotel.Image = newHotel.Image;

            _context.SaveChanges();
        }
    }
}