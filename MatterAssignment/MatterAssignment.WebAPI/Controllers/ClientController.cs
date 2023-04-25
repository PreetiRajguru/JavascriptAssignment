using MatterAssignment.Services.DTO;
using MatterAssignment.Services.Interfaces;
using MatterAssignment.Services.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MatterAssignment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClient _clientService;

        public ClientController(IClient clientService)
        {
            _clientService = clientService;
        }



        [HttpGet]
        public IActionResult GetAll()
        {
            var clients = _clientService.GetAll();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var client = _clientService.GetById(id);
            if (client != null)
            {
                return Ok(client);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(ClientDTO client)
        {
            var newClient = _clientService.Create(client);
            return CreatedAtAction(nameof(GetById), new { id = newClient.Id }, newClient);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_clientService.Delete(id))
            {
                return NoContent();
            }
            return NotFound();
        }

    }
}
