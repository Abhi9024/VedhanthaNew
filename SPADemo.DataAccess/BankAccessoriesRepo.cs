using System;
using System.Collections.Generic;
using System.Text;
using SPADemo.DataAccess.ServiceModel;
using SPADemo.CoreEntity.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SPADemo.DataAccess
{
    public class BankAccessoriesRepo : IBankAccessoriesRepo
    {
        private AngularASPCoreDemoContext _context;

        public BankAccessoriesRepo(AngularASPCoreDemoContext context)
        {
            _context = context;
        }

        public BankServiceModel AddOrUpdate(BankServiceModel bankAcc)
        {
            AngularASPCoreDemoContext bankContext = new AngularASPCoreDemoContext();
            var bankCore = new BankAcessorries()
            {
                ProductName = bankAcc.ProductName,
                ProductDescription = bankAcc.ProductDescription,
                Price = bankAcc.Price,
                ProductCategory = bankAcc.ProductCategory
            };

            var isdataExist = bankContext.BankAcessorries.Where(b => b.ProductName == bankCore.ProductName).FirstOrDefault();

            if (isdataExist != null)
            {
                bankContext.Entry(isdataExist).CurrentValues.SetValues(bankAcc);
                bankContext.Entry(isdataExist).State = EntityState.Modified;
                //bankContext.BankAcessorries.Update(bankCore);
            }
            else
            {
                bankContext.BankAcessorries.Add(bankCore);
            }
            bankContext.SaveChanges();
            bankContext.Dispose();
            return bankAcc;
        }

        public void AddToCart(ProductMemberDetails productMember)
        {
            throw new NotImplementedException();
        }

        public void Delete(string productName)
        {
            AngularASPCoreDemoContext bankContext = new AngularASPCoreDemoContext();
            var duplicateDatas = bankContext.BankAcessorries.Where(b => b.ProductName == productName);
            foreach (var data in duplicateDatas)
            {
                bankContext.BankAcessorries.Remove(data);
            }
            bankContext.SaveChanges();

            bankContext.Dispose();
        }

        public List<BankServiceModel> GetAll()
        {
            AngularASPCoreDemoContext bankContext = new AngularASPCoreDemoContext();
            var bankAccList = bankContext.BankAcessorries.Where(b=>b.Id>=0).ToList();
            var bankAccAllList = new List<BankServiceModel>();
            foreach (var item in bankAccList)
            {
                var bsvc = new BankServiceModel()
                {
                     ProductName = item.ProductName,
                     ProductCategory = item.ProductCategory,
                     Price=item.Price,
                     ProductDescription=item.ProductDescription,
                     ProductImage=item.ProductImage
                };
                bankAccAllList.Add(bsvc);
            }
            bankContext.Dispose();
            return bankAccAllList;
        }
    }
}
