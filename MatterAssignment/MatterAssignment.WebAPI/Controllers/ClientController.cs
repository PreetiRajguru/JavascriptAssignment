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



    }
}
