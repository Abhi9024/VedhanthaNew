using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SPADemo.DataAccess.ServiceModel;
using SPADemo.DataAccess;
using SPADemo.CoreEntity.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SPADemo.Controllers
{
    [Route("api/BankAcc")]
    public class BankAccController : Controller
    {
        private readonly IBankAccessoriesRepo _bankAccRepo;
        private readonly AngularASPCoreDemoContext _context;

        public BankAccController(IBankAccessoriesRepo bankAccRepo, AngularASPCoreDemoContext context)
        {
            _bankAccRepo = bankAccRepo;
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        [Route("GetAll")]
        public List<BankServiceModel> GetAll()
        {
            var result = _bankAccRepo.GetAll();

            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [Route("Post")]
        public BankServiceModel Post([FromBody]BankServiceModel bankacc)
        {
            var result = _bankAccRepo.AddOrUpdate(bankacc);
            return result;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("Delete")]
        public void Delete(string name)
        {
            _bankAccRepo.Delete(name);
        }
    }
}
