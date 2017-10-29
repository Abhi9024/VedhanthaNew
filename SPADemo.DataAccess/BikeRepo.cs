using Microsoft.EntityFrameworkCore;
using SPADemo.CoreEntity.Models;
using SPADemo.ServiceModel;
using System.Collections.Generic;
using System.Linq;

namespace SPADemo.DataAccess
{
    public class BikeRepo : IBikeRepo
    {
        public BikeServiceModel AddBike(BikeServiceModel bike)
        {
            AngularASPCoreDemoContext bikeContext = new AngularASPCoreDemoContext();
            var bikeType = bikeContext.BikeType.Where(bt => bt.TypeName == bike.Type).FirstOrDefault();
            var bikeCore = new Bike()
            {
                Name= bike.Name,
                Company = bike.Company,
                Type = bikeType.Id
            };
            var bikeList = bikeContext.Bike.Add(bikeCore);
            bikeContext.SaveChanges();
            bikeContext.Dispose();
            return bike;
        }

        public List<BikeServiceModel> GetAll()
        {
            AngularASPCoreDemoContext bikeContext = new AngularASPCoreDemoContext();
            var bikeList = bikeContext.Bike.Include(b=>b.TypeNavigation).Where(b => b.Id > 0).ToList();
            var bikeAllList = new List<BikeServiceModel>();
            foreach (var b in bikeList)
            {
                var bike = new BikeServiceModel()
                {
                    Name = b.Name,
                    Company=b.Company,
                    Type=b.TypeNavigation.TypeName
                };
                bikeAllList.Add(bike);
            }
            bikeContext.Dispose(); 
            return bikeAllList;
        }
    }
}
