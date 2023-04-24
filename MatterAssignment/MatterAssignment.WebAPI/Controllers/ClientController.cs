using MatterAssignment.Services.DTO;
using MatterAssignment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MatterAssignment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        public readonly IClient _clientService;

        public ClientController(IClient clientService)
        {
            _clientService = clientService;
        }

        //get all customers
        [HttpGet]
        public async Task<ActionResult<List<ClientDTO>>> GetAllClients()
        {
            var clients = await _clientService.GetAllClients();
            return Ok(clients);
        }


        [HttpGet("{id}")]
        public ActionResult<ClientDTO> GetById(int id)
        {
            var client = _clientService.GetById(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }


        [HttpPost]
        public ActionResult<ClientDTO> Create([FromBody] ClientDTO clientDto)
        {
            if (clientDto == null)
            {
                return BadRequest("Client data is null.");
            }

            var createdClient = _clientService.Create(clientDto);

            // return 201 Created response with location header
            return CreatedAtAction(nameof(GetById), new { id = createdClient.Id }, createdClient);
        }

    }
}
