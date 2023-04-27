using MatterAssignment.Services.DTO;
using MatterAssignment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
            try
            {
                IEnumerable<MatterDTO> matters = _matterService.GetAll();
                return Ok(matters);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetMatterById(int id)
        {
            try
            {
                MatterDTO matter = _matterService.GetById(id);
                if (matter == null)
                {
                    return NotFound();
                }

                return Ok(matter);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateMatter(MatterDTO matterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (matterDto == null)
                {
                    return BadRequest();
                }

                MatterDTO createdMatter = _matterService.Create(matterDto);
                return CreatedAtAction(nameof(GetMatterById), new { id = createdMatter.Id }, createdMatter);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMatter(int id)
        {
            try
            {
                _matterService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("client/{clientId}")]
        public IActionResult GetMattersForClient(int clientId)
        {
            try
            {
                List<MatterForClientDTO> matters = _matterService.GetMattersForClient(clientId);

                if (matters == null)
                {
                    return NotFound();
                }

                return Ok(matters);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("client")]
        public IActionResult GetMattersByClients()
        {
            try
            {
                IEnumerable<ClientMatterDTO> groupedMatters = _matterService.GetMattersByClients();

                return Ok(groupedMatters);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
