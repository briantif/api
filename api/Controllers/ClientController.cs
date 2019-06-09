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
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
               _clientService.GetAll()
            );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
              _clientService.Get(id)
          );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Client model)
        {
            return Ok(
                _clientService.Add(model)
            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Client model)
        {
            return Ok(
                _clientService.Update(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _clientService.Delete(id)
            );
        }
    }
}
