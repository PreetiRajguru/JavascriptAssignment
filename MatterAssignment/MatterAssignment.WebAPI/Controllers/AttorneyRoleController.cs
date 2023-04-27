using MatterAssignment.Services.DTO;
using MatterAssignment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MatterAssignment.WebAPI.Controllers
{
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
            try
            {
                IEnumerable<AttorneyRoleDTO> attorneyRoles = _attorneyRoleService.GetAll();

                return Ok(attorneyRoles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                AttorneyRoleDTO attorneyRole = _attorneyRoleService.GetById(id);

                if (attorneyRole == null)
                {
                    return NotFound();
                }

                return Ok(attorneyRole);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] AttorneyRoleDTO attorneyRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (attorneyRole == null)
                {
                    return BadRequest();
                }

                _attorneyRoleService.Create(attorneyRole);

                return CreatedAtRoute(nameof(GetById), new { id = attorneyRole.Id }, attorneyRole);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _attorneyRoleService.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
