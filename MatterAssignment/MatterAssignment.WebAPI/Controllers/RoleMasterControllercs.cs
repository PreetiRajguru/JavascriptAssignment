using MatterAssignment.Services.DTO;
using MatterAssignment.Services.Interfaces;
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
            try
            {
                var roles = _roleMasterService.GetAll();
                return Ok(roles);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var role = _roleMasterService.GetById(id);
                if (role != null)
                {
                    return Ok(role);
                }
                return NotFound();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult Create(RoleMasterDTO role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newRole = _roleMasterService.Create(role);
                return CreatedAtAction(nameof(GetById), new { id = newRole.Id }, newRole);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_roleMasterService.Delete(id))
                {
                    return NoContent();
                }
                return NotFound();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
