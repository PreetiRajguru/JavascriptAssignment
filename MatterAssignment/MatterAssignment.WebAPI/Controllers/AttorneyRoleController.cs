using MatterAssignment.Services.DTO;
using MatterAssignment.Services.Interfaces;
using MatterAssignment.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace MatterAssignment.WebAPI.Controllers
{
    // Controller
    [ApiController]
    [Route("api/[controller]")]
    public class AttorneyRoleController : ControllerBase
    {
        private readonly IAttorneyRole _attorneyRoleService;

        public AttorneyRoleController(IAttorneyRole attorneyRoleService)
        {
            _attorneyRoleService = attorneyRoleService;
        }

        [HttpGet]
        public IActionResult GetAllAttorneyRoles()
        {
            var attorneyRoles = _attorneyRoleService.GetAllAttorneyRoles();

            return Ok(attorneyRoles);
        }

        [HttpGet("{id}")]
        public IActionResult GetAttorneyRoleById(int id)
        {
            var attorneyRole = _attorneyRoleService.GetAttorneyRoleById(id);

            if (attorneyRole == null)
            {
                return NotFound();
            }

            return Ok(attorneyRole);
        }

        [HttpPost]
        public IActionResult CreateAttorneyRole([FromBody] AttorneyRoleDTO attorneyRole)
        {
            if (attorneyRole == null)
            {
                return BadRequest();
            }

            _attorneyRoleService.CreateAttorneyRole(attorneyRole);

            return CreatedAtRoute(nameof(GetAttorneyRoleById), new { id = attorneyRole.Id }, attorneyRole);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAttorneyRole(int id)
        {
            _attorneyRoleService.DeleteAttorneyRole(id);

            return NoContent();
        }
    }

}
