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
        public IActionResult GetAll()
        {
            IEnumerable<AttorneyDTO> attorneys = _attorneyService.GetAll();

            return Ok(attorneys);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            AttorneyDTO attorney = _attorneyService.GetById(id);

            if (attorney == null)
            {
                return NotFound();
            }

            return Ok(attorney);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AttorneyDTO attorney)
        {
            if (attorney == null)
            {
                return BadRequest();
            }

            _attorneyService.Create(attorney);

            return CreatedAtRoute(nameof(GetById), new { id = attorney.Id }, attorney);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _attorneyService.Delete(id);

            return NoContent();
        }
    }

}
