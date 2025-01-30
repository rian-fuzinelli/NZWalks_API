
using Microsoft.AspNetCore.Mvc;
using NZWalks.Application.DTOs;
using NZWalks.Domain.Models;
using NZWalks.Infrastructure.Data;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {

        private readonly NZWalksDbContext _dbContext;

        public RegionsController(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = _dbContext.Regions.ToList();

            var regionsDto = new List<RegionDto>();

            foreach (var region in regions) 
            {
                regionsDto.Add(new RegionDto(region.Code, region.Name)
                {
                    Code = region.Code,
                    Name = region.Name
                });
            }

            return Ok(regionsDto);
        }

        [HttpGet("{id}")]

        public IActionResult GetById([FromRoute] Guid id)
        {
           var region = _dbContext.Regions.FirstOrDefault(x => x.Id == id);

            var regionsDto = new RegionDto(region.Code, region.Name)
            {
                Code = region.Code,
                Name = region.Name
            };

            if (region == null)
            {
                return NotFound();
            }
            return Ok(region);
        }
    }
}
