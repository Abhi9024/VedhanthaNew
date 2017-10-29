using System;
using System.Collections.Generic;

namespace SPADemo.CoreEntity.Models
{
    public partial class BankCategory
    {
        public BankCategory()
        {
            BankAcessorries = new HashSet<BankAcessorries>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<BankAcessorries> BankAcessorries { get; set; }
    }
}
