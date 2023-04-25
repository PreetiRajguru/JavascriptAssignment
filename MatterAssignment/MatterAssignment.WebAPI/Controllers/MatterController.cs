using MatterAssignment.Data.Models;
using MatterAssignment.Services.DTO;
using MatterAssignment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MatterAssignment.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MattersController : ControllerBase
    {
        private readonly IMatter _matterService;

        public MattersController(IMatter matterService)
        {
            _matterService = matterService;
        }

        [HttpGet]
        public IActionResult GetAllMatters()
        {
            var matters = _matterService.GetAllMatters();
            return Ok(matters);
        }

        [HttpGet("{id}")]
        public IActionResult GetMatterById(int id)
        {
            var matter = _matterService.GetMatterById(id);
            if (matter == null)
            {
                return NotFound();
            }

            return Ok(matter);
        }

        [HttpPost]
        public IActionResult CreateMatter(MatterDTO matterDto)
        {
            if (matterDto == null)
            {
                return BadRequest();
            }

            var createdMatter = _matterService.CreateMatter(matterDto);
            return CreatedAtAction(nameof(GetMatterById), new { id = createdMatter.Id }, createdMatter);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMatter(int id)
        {
            _matterService.DeleteMatter(id);
            return NoContent();
        }

        [HttpGet("byclient/{clientId}")]
        public IActionResult GetMattersByClientId(int clientId)
        {
            var matters = _matterService.GetMattersByClientId(clientId);

            if (matters == null)
            {
                return NotFound();
            }

            return Ok(matters);
        }


        

    }

}
