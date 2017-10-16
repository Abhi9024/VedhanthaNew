﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SPADemo.DataAccess;
using SPADemo.CoreEntity.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SPADemo.Controllers
{
    [Route("api/Bike")]
    public class BikeController : Controller
    {
        private readonly IBikeRepo _bikeRepo;

        public BikeController(IBikeRepo bikeRepo)
        {
            _bikeRepo = bikeRepo;
        }
        //GET: api/values
       [HttpGet("[action]")]
        public List<Bike> GetAllBikeInfo()
        {
            var test = _bikeRepo.GetAll();
            return test;
        }

        //GET api/values/5
        [HttpGet("{id}")]
        public Bike Get(int id)
        {
            var data = new Bike()
            {
                Name = "Hayabusa",
                Company = "Yamaha",
                Type = 1
            };

            return data;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
