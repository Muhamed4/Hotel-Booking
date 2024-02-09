using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;

namespace Hotel_Booking.Repository.RoomsRepo
{
    public interface IRoomRepo
    {
        List<Room> GetAllRooms();
        Room GetById(int id);
        void Insert(Room room);
        void Update(int id, Room newRoom);
        void Delete(int id);
        bool CheckRoomByHotelId(int roomNumber, int hotelId);
        string UploadImage(IFormFile File);
        void BookRoom(UserBookRoom _book);
        void CancelBookRoom(int RoomId, string UserId);
    }
}