using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Data;
using Hotel_Booking.Models;
using Hotel_Booking.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Hotel_Booking.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Get the current instance of the class
            var UserData = (Registration)validationContext.ObjectInstance;

            // Use a service to check uniqueness
            // This method is used to retrieve a service of the specified type (IRoomRepo) from the dependency injection container.
            // get an instance of the IRoomRepo service from the dependency injection container within the context of the validation process. 
            var validationService = (AppDbContext)validationContext.GetService(typeof(AppDbContext));

            if (validationService == null || !CheckUniquenessEmail((string)value, validationService))
            {
                return new ValidationResult("This Email is already exists");
            }

            return ValidationResult.Success;
        }

        private bool CheckUniquenessEmail(string value, AppDbContext context)
        {
            var check = context.Users.SingleOrDefault(X => X.Email == value);

            if(check is null)
                return true;

            return false;
        }
    }
}