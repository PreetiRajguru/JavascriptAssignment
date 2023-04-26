using MatterAssignment.Services.DTO;
using MatterAssignment.Services.Interfaces;
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
        public IActionResult GetAll()
        {
            IEnumerable<AttorneyRoleDTO> attorneyRoles = _attorneyRoleService.GetAll();

            return Ok(attorneyRoles);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            AttorneyRoleDTO attorneyRole = _attorneyRoleService.GetById(id);

            if (attorneyRole == null)
            {
                return NotFound();
            }

            return Ok(attorneyRole);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AttorneyRoleDTO attorneyRole)
        {
            if (attorneyRole == null)
            {
                return BadRequest();
            }

            _attorneyRoleService.Create(attorneyRole);

            return CreatedAtRoute(nameof(GetById), new { id = attorneyRole.Id }, attorneyRole);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _attorneyRoleService.Delete(id);

            return NoContent();
        }
    }

}
