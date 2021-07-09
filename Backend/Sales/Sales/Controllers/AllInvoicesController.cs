using Microsoft.AspNetCore.Mvc;
using Sales.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Controllers
{
     [Route("api/[controller]")]
    [ApiController]
    public class AllInvoicesController : ControllerBase
    {
        private readonly IAllInvoices _db;

        public AllInvoicesController(IAllInvoices db)
        {
            _db = db;
        }

        [HttpGet("Invoices")]
        public async Task<IActionResult> AllInvoices()
        {
            return Ok(await _db.GetAll());
        }

        [HttpGet("Invoice/{id}")]
        public async Task<IActionResult>InvoiceByID(int id)
        {
            return Ok(await _db.GetInvoiceByID(id));
        }

        [HttpDelete("DeleteInvoiceDetails/{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.DeleteInvoiceDetails(id);
            return Ok(result);
        }
    }
}
