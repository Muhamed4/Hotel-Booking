using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Data;
using Hotel_Booking.Models;

namespace Hotel_Booking.Repository.RoomsRepo
{
    public class RoomRepo : IRoomRepo
    {
        private readonly AppDbContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;
        public RoomRepo(AppDbContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            this._context = context;
            this._hosting = hosting;
        }
        public void Delete(int id)
        {
            var room = GetById(id);
            if(room is not null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }
        }

        public List<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }

        public Room GetById(int id)
        {
            var _room = _context.Rooms.FirstOrDefault(X => X.ID == id);
            return _room;
        }

        public void Insert(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        public void Update(int id, Room newRoom)
        {
            var _oldRoom = GetById(id);
            _oldRoom.Price = newRoom.Price;
            _oldRoom.RoomNumber = newRoom.RoomNumber;
            _oldRoom.BedCount = newRoom.BedCount;

            _context.SaveChanges();
        }

        public bool CheckRoomByHotelId(int roomNumber, int hotelId){

            var _room = _context.Rooms.FirstOrDefault(X => X.HotelID == hotelId && X.RoomNumber == roomNumber);

            if(_room is null)
                return true;
                
            return false;
        }

        public string UploadImage(IFormFile File)
        {
            string fileName = string.Empty;
            if (File is not null)
            {
                string imagesPath = Path.Combine(_hosting.WebRootPath, "RoomImages");
                fileName = Guid.NewGuid().ToString() + "_" + File.FileName;
                string fullPath = Path.Combine(imagesPath, fileName);
                File.CopyTo(new FileStream(fullPath, FileMode.Create));
            }

            return fileName;
        }
    }
}