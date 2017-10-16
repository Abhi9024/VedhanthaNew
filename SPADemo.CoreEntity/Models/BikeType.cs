using System;
using System.Collections.Generic;

namespace SPADemo.CoreEntity.Models
{
    public partial class BikeType
    {
        public BikeType()
        {
            Bike = new HashSet<Bike>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }

        public ICollection<Bike> Bike { get; set; }
    }
}
