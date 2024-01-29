using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;

namespace Hotel_Booking.Repository.RoomImageRepo
{
    public interface IRoomImageRepo
    {
        void Insert(RoomImage roomImage);
    }
}