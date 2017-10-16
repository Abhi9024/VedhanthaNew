using System;
using System.Collections.Generic;
using SPADemo.CoreEntity.Models;
using System.Linq;

namespace SPADemo.DataAccess
{
    public class BikeRepo : IBikeRepo
    {
        public List<Bike> GetAll()
        {
            AngularASPCoreDemoContext bikeContext = new AngularASPCoreDemoContext();
            var bikeList = bikeContext.Bike.Where(b => b.Id > 0).ToList();
            bikeContext.Dispose();
            return bikeList;
        }
    }
}
