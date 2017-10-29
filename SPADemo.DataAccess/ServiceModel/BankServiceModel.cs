using System;
using System.Collections.Generic;
using System.Text;

namespace SPADemo.DataAccess.ServiceModel
{
    public class BankServiceModel
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public byte[] ProductImage { get; set; }
        public int? ProductCategory { get; set; }
        public long? Price { get; set; }
    }
}
