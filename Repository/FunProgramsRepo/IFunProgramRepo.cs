using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;

namespace Hotel_Booking.Repository.FunProgramsRepo
{
    public interface IFunProgramRepo
    {
        void Insert(FunProgram funProgram);
        void Insert(string funProgram, int featureId);
    }
}