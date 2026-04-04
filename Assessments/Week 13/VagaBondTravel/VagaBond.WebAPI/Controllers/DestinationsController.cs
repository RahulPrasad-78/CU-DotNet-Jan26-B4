using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VagaBond.WebAPI.Data;
using VagaBond.WebAPI.Model;
using VagaBond.WebAPI.Repository;
using VagaBond.WebAPI.Service;

namespace VagaBond.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private readonly IDestinationService _service;

        public DestinationsController(IDestinationService service)
        {
            _service = service;
        }

        // GET: api/Destinations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Destination>>> GetDestination()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }

        // GET: api/Destinations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Destination>> GetDestination(int id)
        {
            var destination = await _service.GetByIdAsync(id);

            if (destination == null)
                return NotFound();

            return Ok(destination);
        }

        // POST: api/Destinations
        [HttpPost]
        public async Task<ActionResult<Destination>> PostDestination(Destination destination)
        {
            if(destination.Rating > 5)
            {
                throw new Assessment13.Middleware.InvalidRatingException("Rating must be between 1 and 5");
            }
            await _service.AddAsync(destination);

            return CreatedAtAction(nameof(GetDestination),
                new { id = destination.Id }, destination);
        }

        // PUT: api/Destinations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDestination(int id, Destination destination)
        {
            if (id != destination.Id)
                return BadRequest();

            try
            {
                await _service.UpdateAsync(destination);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Destinations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestination(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
