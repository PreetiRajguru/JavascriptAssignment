using MatterAssignment.Services.DTO;
using MatterAssignment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

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

        // Controller method
        [HttpGet]
        public ActionResult<IEnumerable<GetAllClientsResponse>> GetAllClients()
        {
            var clients = _clientService.GetAll();
            var response = clients.Select(c => new GetAllClientsResponse
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                PhoneNumber = c.PhoneNumber,
                Email = c.Email,
                Address = c.Address
            });
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<GetClientByIdResponse> GetClientById(int id)
        {
            var client = _clientService.GetById(id);
            var response = new GetClientByIdResponse
            {
                Id = client.Id,
                Client = client
            };
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create(ClientDTO client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                ClientDTO newClient = _clientService.Create(client);
                return CreatedAtAction(nameof(GetClientById), new { id = newClient.Id }, newClient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_clientService.Delete(id))
                {
                    return NoContent();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
