using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;

namespace Hotel_Booking.Repository.FeaturesRepo
{
    public interface IFeatureRepo
    {
        List<Feature> GetAllFeature();
        Feature GetById(int id);
        void Insert(Feature hotel);
        void Update(int id, Feature newHotel);
        void Delete(int id);
    }
}