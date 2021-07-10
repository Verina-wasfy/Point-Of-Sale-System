using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Models;
using Sales.Services.Interfaces;
using Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _db;
        public CustomerController(ICustomer db)
        {
            _db = db;
        }

        [HttpGet("Customers")]
        public async Task<IActionResult> AllCustomers()
        {
            return Ok(await _db.GetAll());
        }

        // POST: api/Customer
        [HttpPost]
        public async Task<ActionResult<CustomerDataModel>> NewCustomer(CustomerDataModel Cx)
        {
            await _db.Add(Cx);
            return Ok(Cx);
        }
    }
}
