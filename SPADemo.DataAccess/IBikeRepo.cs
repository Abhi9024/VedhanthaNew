using SPADemo.ServiceModel;
using System.Collections.Generic;

namespace SPADemo.DataAccess
{
    public interface IBikeRepo
    {
        List<BikeServiceModel> GetAll();
        BikeServiceModel AddBike(BikeServiceModel bike);
    }
}
