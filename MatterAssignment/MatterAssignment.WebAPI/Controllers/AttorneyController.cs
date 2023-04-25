using MatterAssignment.Services.DTO;
using MatterAssignment.Services.Interfaces;
using MatterAssignment.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace MatterAssignment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttorneyController : ControllerBase
    {
        private readonly IAttorney _attorneyService;

        public AttorneyController(IAttorney attorneyService)
        {
            _attorneyService = attorneyService;
        }

        [HttpGet]
        public IActionResult GetAllAttorneys()
        {
            var attorneys = _attorneyService.GetAllAttorneys();

            return Ok(attorneys);
        }

        [HttpGet("{id}")]
        public IActionResult GetAttorneyById(int id)
        {
            var attorney = _attorneyService.GetAttorneyById(id);

            if (attorney == null)
            {
                return NotFound();
            }

            return Ok(attorney);
        }

        [HttpPost]
        public IActionResult CreateAttorney([FromBody] AttorneyDTO attorney)
        {
            if (attorney == null)
            {
                return BadRequest();
            }

            _attorneyService.CreateAttorney(attorney);

            return CreatedAtRoute(nameof(GetAttorneyById), new { id = attorney.Id }, attorney);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAttorney(int id)
        {
            _attorneyService.DeleteAttorney(id);

            return NoContent();
        }
    }

}
