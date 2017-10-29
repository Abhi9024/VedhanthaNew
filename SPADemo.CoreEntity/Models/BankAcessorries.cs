using System;
using System.Collections.Generic;

namespace SPADemo.CoreEntity.Models
{
    public partial class BankAcessorries
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public byte[] ProductImage { get; set; }
        public int? ProductCategory { get; set; }
        public long? Price { get; set; }

        public BankCategory ProductCategoryNavigation { get; set; }
    }
}
