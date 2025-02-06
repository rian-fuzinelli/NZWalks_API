using Microsoft.AspNetCore.Mvc;
using NZWalks.Domain.Models;
using NZWalks.Domain.Repositories;
using NZWalks.Domain.Services;
using NZWalks.Infrastructure.Data;

namespace NZWalks.API.Controllers
{
    [Route("api/regions")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly RegionService _regionService;

        public RegionsController(RegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RegionEntity>>> GetAll()
        {
            return Ok(await _regionService.GetAllAsync());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<RegionEntity>> GetById([FromRoute] Guid id)
        {
            return Ok(await _regionService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<RegionEntity>> Create([FromBody] RegionEntity request)
        {
            var region = await _regionService.CreateAsync(request);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] RegionEntity request)
        {
            await _regionService.UpdateAsync(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _regionService.Remove(id);
            return Ok();
        }

    }
}
