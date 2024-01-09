using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Booking.Models
{
    public class FunProgram
    {
        public int ID { get; set; }
        public string Description { get; set; } = null!;
        public int FeatureID { get; set; }
        public virtual Feature Feature { get; set; } = null!;
    }
}