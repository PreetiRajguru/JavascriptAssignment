﻿using MatterAssignment.Services.DTO;
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
            try
            {
                IEnumerable<JurisdictionMasterDTO> jurisdictions = _jurisdictionMasterService.GetAll();
                return Ok(jurisdictions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the jurisdictions.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetJurisdictionMasterById(int id)
        {
            try
            {
                JurisdictionMasterDTO jurisdiction = _jurisdictionMasterService.GetById(id);
                if (jurisdiction == null)
                {
                    return NotFound();
                }
                return Ok(jurisdiction);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the jurisdiction.");
            }
        }

        [HttpPost]
        public IActionResult CreateJurisdictionMaster([FromBody] JurisdictionMasterDTO jurisdictionMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (jurisdictionMaster == null)
                {
                    return BadRequest();
                }

                _jurisdictionMasterService.Create(jurisdictionMaster);

                return CreatedAtRoute(nameof(GetJurisdictionMasterById), new { id = jurisdictionMaster.Id }, jurisdictionMaster);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the jurisdiction.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJurisdictionMaster(int id)
        {
            try
            {
                _jurisdictionMasterService.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the jurisdiction.");
            }
        }
    }

}
