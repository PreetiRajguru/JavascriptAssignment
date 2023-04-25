using MatterAssignment.Services.DTO;
using MatterAssignment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MatterAssignment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JurisdictionMasterController : ControllerBase
    {
        private readonly IJurisdictionMaster _jurisdictionMasterService;

        public JurisdictionMasterController(IJurisdictionMaster jurisdictionMasterService)
        {
            _jurisdictionMasterService = jurisdictionMasterService;
        }

        [HttpGet]
        public IActionResult GetAllJurisdictionMasters()
        {
            IEnumerable<JurisdictionMasterDTO> jurisdictions = _jurisdictionMasterService.GetAll();

            return Ok(jurisdictions);
        }

        [HttpGet("{id}")]
        public IActionResult GetJurisdictionMasterById(int id)
        {
            JurisdictionMasterDTO jurisdiction = _jurisdictionMasterService.GetById(id);

            if (jurisdiction == null)
            {
                return NotFound();
            }

            return Ok(jurisdiction);
        }

        [HttpPost]
        public IActionResult CreateJurisdictionMaster([FromBody] JurisdictionMasterDTO jurisdictionMaster)
        {
            if (jurisdictionMaster == null)
            {
                return BadRequest();
            }

            _jurisdictionMasterService.Create(jurisdictionMaster);

            return CreatedAtRoute(nameof(GetJurisdictionMasterById), new { id = jurisdictionMaster.Id }, jurisdictionMaster);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJurisdictionMaster(int id)
        {
            _jurisdictionMasterService.Delete(id);

            return NoContent();
        }
    }

}
