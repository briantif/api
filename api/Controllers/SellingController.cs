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
    public class SellingController : Controller
    {
        private readonly ISellingService _sellingService;

        public SellingController(ISellingService sellingService)
        {
            _sellingService = sellingService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
               _sellingService.GetAll()
            );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(
              _sellingService.Get(id)
          );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Selling model)
        {
            return Ok(
                _sellingService.Add(model)
            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Selling model)
        {
            return Ok(
                _sellingService.Update(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(
                _sellingService.Delete(id)
            );
        }
    }
}
