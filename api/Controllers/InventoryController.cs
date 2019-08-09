using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

namespace api.Controllers
{
    [Route("[controller]")]
    public class InventoryController : Controller
    {
        private readonly IInventoryService _InventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _InventoryService = inventoryService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
               _InventoryService.GetAll()
            );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(
              _InventoryService.Get(id)
          );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Inventory model)
        {
            return Ok(
                _InventoryService.Add(model)
            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Inventory model)
        {
            return Ok(
                _InventoryService.Update(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(
                _InventoryService.Delete(id)
            );
        }
    }
}
