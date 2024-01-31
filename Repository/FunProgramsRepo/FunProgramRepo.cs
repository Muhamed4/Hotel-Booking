using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Data;
using Hotel_Booking.Models;

namespace Hotel_Booking.Repository.FunProgramsRepo
{
    public class FunProgramRepo : IFunProgramRepo
    {
        private readonly AppDbContext _context;
        public FunProgramRepo(AppDbContext context)
        {
            this._context = context;
        }
        public void Insert(FunProgram funProgram)
        {
            _context.FunPrograms.Add(funProgram);
            _context.SaveChanges();
        }

        public void Insert(string funProgram, int featureId)
        {
            if (funProgram is not null)
            {
                var _funProgram = new FunProgram()
                {
                    Description = funProgram,
                    FeatureID = featureId
                };
                _context.FunPrograms.Add(_funProgram);
                _context.SaveChanges();
            }
        }
    }
}