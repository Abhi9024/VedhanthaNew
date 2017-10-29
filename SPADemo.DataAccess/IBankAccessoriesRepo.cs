using SPADemo.DataAccess.ServiceModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPADemo.DataAccess
{
    public interface IBankAccessoriesRepo
    {
        List<BankServiceModel> GetAll();
        BankServiceModel AddOrUpdate(BankServiceModel bankAcc);
        void Delete(string productName);
        void AddToCart(ProductMemberDetails productMember);
    }
}
