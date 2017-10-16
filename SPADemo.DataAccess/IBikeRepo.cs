using SPADemo.CoreEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPADemo.DataAccess
{
    public interface IBikeRepo
    {
        List<Bike> GetAll();
    }
}
