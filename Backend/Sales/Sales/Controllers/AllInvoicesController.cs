using Microsoft.AspNetCore.Mvc;
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
    public class AllInvoicesController : ControllerBase
    {
        private readonly IAllInvoices _db;
        private readonly IInvoiceFill _BB;

        public AllInvoicesController(IAllInvoices db,IInvoiceFill BB)
        {
            _db = db;
            _BB = BB;
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

        [HttpPost("AddInvoice")]
        public async Task<IActionResult> AddInvoice(InvoiceDetailsModel InvDet)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _BB.Add(InvDet);
            return Ok(result);
        }

        [HttpPut("EditInvoice")]
        public async Task<IActionResult> EditInvoice(InvoiceDetailsModel c1)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _BB.Edit(c1);
            return Ok(result);
        }
    }
}
