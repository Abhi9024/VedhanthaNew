using System;
using System.Collections.Generic;

namespace SPADemo.CoreEntity.Models
{
    public partial class Bike
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public int? Type { get; set; }

        public BikeType TypeNavigation { get; set; }
    }
}
