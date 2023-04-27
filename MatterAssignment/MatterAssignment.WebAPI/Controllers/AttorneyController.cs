using MatterAssignment.Services.DTO;
using MatterAssignment.Services.Interfaces;
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
            var attorneys = _attorneyService.GetAll();

            if (attorneys == null || !attorneys.Any())
            {
                return NotFound();
            }

            return Ok(attorneys);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                AttorneyDTO attorney = _attorneyService.GetById(id);

                if (attorney == null)
                {
                    return NotFound();
                }

                return Ok(attorney);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] AttorneyDTO attorney)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (attorney == null)
                {
                    return BadRequest();
                }

                _attorneyService.Create(attorney);

                return CreatedAtRoute(nameof(GetById), new { id = attorney.Id }, attorney);
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
                _attorneyService.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
