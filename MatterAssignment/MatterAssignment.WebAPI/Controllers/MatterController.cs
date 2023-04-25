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
            IEnumerable<MatterDTO> matters = _matterService.GetAll();
            return Ok(matters);
        }

        [HttpGet("{id}")]
        public IActionResult GetMatterById(int id)
        {
            MatterDTO matter = _matterService.GetById(id);
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

            MatterDTO createdMatter = _matterService.Create(matterDto);
            return CreatedAtAction(nameof(GetMatterById), new { id = createdMatter.Id }, createdMatter);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMatter(int id)
        {
            _matterService.Delete(id);
            return NoContent();
        }

        [HttpGet("client/{clientId}")]
        public IActionResult GetMattersByClientId(int clientId)
        {
            IEnumerable<MatterDTO> matters = _matterService.GetMattersByClientId(clientId);

            if (matters == null)
            {
                return NotFound();
            }

            return Ok(matters);
        }


        [HttpGet("client")]
        public IActionResult GetMattersGroupedByClient()
        {
            Dictionary<int, List<MatterDTO>> groupedMatters = _matterService.GetMattersGroupedByClientId();

            return Ok(groupedMatters);
        }

    }

}
