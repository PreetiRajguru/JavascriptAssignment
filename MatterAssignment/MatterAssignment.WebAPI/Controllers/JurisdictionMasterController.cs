using MatterAssignment.Services.DTO;
using MatterAssignment.Services.Interfaces;
using MatterAssignment.Services.Services;
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
            var jurisdictions = _jurisdictionMasterService.GetAllJurisdictionMasters();

            return Ok(jurisdictions);
        }

        [HttpGet("{id}")]
        public IActionResult GetJurisdictionMasterById(int id)
        {
            var jurisdiction = _jurisdictionMasterService.GetJurisdictionMasterById(id);

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

            _jurisdictionMasterService.CreateJurisdictionMaster(jurisdictionMaster);

            return CreatedAtRoute(nameof(GetJurisdictionMasterById), new { id = jurisdictionMaster.Id }, jurisdictionMaster);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJurisdictionMaster(int id)
        {
            _jurisdictionMasterService.DeleteJurisdictionMaster(id);

            return NoContent();
        }
    }

}
