using System;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCP_Pulse_Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController:ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;

        public ClientController(IRepositoryWrapper repoWrapper)
        {
            this._repoWrapper = repoWrapper; 
        }

        [HttpGet]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllClient()
        {
            try
            {
                var clients = _repoWrapper.Client.FindAll();
                Console.WriteLine($"Returned all clients from database.");

                return clients == null ? NotFound() : Ok(clients);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong inside GetAllClient action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


       


        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var client = _repoWrapper.Client.FindByCondition(x=>x.ClientId == id);
                return client == null ? NotFound() : Ok(client);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong inside GetById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] Client client)
        {   
            try {

                _repoWrapper.Client.Create(client);
                _repoWrapper.Save();
                return CreatedAtAction(nameof(GetById), new { id = client.ClientId }, client);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong inside Post action: {ex.Message}");
                return StatusCode(500, "Internal server error");
    }
}

        
        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(Guid id, Client client)
        {
            try
            {
                if (id != client.ClientId) return BadRequest();

                _repoWrapper.Client.Update(client);
                _repoWrapper.Save();
                return NoContent();

            }catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong inside Update action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Client clientToDelete = _repoWrapper.Client.FindByCondition(x => x.ClientId == id).First();
                if (clientToDelete == null) return NotFound();

                _repoWrapper.Client.Delete(clientToDelete);
                _repoWrapper.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong inside GetAllClient action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
            }
    }
}

