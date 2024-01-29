using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Repository.RoomsRepo;
using Hotel_Booking.ViewModels;

namespace Hotel_Booking.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class UniqueRoomNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Get the current instance of the class
            var roomDataInstance = (RoomData)validationContext.ObjectInstance;

            // Use a service to check uniqueness
            // This method is used to retrieve a service of the specified type (IRoomRepo) from the dependency injection container.
            // get an instance of the IRoomRepo service from the dependency injection container within the context of the validation process. 
            var validationService = (IRoomRepo)validationContext.GetService(typeof(IRoomRepo));

            if (validationService != null && !validationService.CheckRoomByHotelId(roomDataInstance.RoomNumber, roomDataInstance.hotelID))
            {
                return new ValidationResult("Room number must be unique per hotel.");
            }

            return ValidationResult.Success;
        }

        // private bool IsRoomNumberUnique(int roomNumber, int hotelID)
        // {
        //     var check = _roomRepo.CheckRoomByHotelId(roomNumber, hotelID);
        //     return check;
        // }
    }

}