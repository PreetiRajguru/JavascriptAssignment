using MatterAssignment.Services.DTO;
using MatterAssignment.Services.Interfaces;
using MatterAssignment.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace MatterAssignment.WebAPI.Controllers
{
    // Controller
    [ApiController]
    [Route("api/[controller]")]
    public class RoleMasterController : ControllerBase
    {
        private readonly IRoleMaster _roleMasterService;

        public RoleMasterController(IRoleMaster roleMasterService)
        {
            _roleMasterService = roleMasterService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var roles = _roleMasterService.GetAll();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var role = _roleMasterService.GetById(id);
            if (role != null)
            {
                return Ok(role);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(RoleMasterDTO role)
        {
            var newRole = _roleMasterService.Create(role);
            return CreatedAtAction(nameof(GetById), new { id = newRole.Id }, newRole);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_roleMasterService.Delete(id))
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
