using Microsoft.AspNetCore.Http;
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
    public class ItemsController : ControllerBase
    {
        private readonly IItems _db;

        public ItemsController(IItems db)
        {
            _db = db;
        }

        [HttpGet("Items")]
        public async Task<IActionResult> AllItems()
        {
            return Ok(await _db.GetAll());
        }

        [HttpGet("UnitPrice/{id}")]
        public async Task<IActionResult> UnitPriceByID(int id)
        {
            return Ok(await _db.GetUnitPriceByID(id));
        }
    }
}
