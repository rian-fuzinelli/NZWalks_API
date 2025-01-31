
using Microsoft.AspNetCore.Mvc;
using NZWalks.Application.DTOs;
using NZWalks.Domain.Models;
using NZWalks.Infrastructure.Data;

namespace NZWalks.API.Controllers
{
    [Route("api/regions")]
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
                regionsDto.Add(new RegionDto(region.Code, region.Name, region.RegionImageUrl)
                {
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl
                });
            }

            return Ok(regionsDto);
        }

        [HttpGet("{id}")]

        public IActionResult GetById([FromRoute] Guid id)
        {
           var region = _dbContext.Regions.FirstOrDefault(x => x.Id == id);

            var regionsDto = new RegionDto(region.Code, region.Name, region.RegionImageUrl)
            {
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };

            if (region == null)
            {
                return NotFound();
            }
            return Ok(regionsDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] RegionDto requestDto)
        {
            var region = new Region
            {
                Code = requestDto.Code,
                Name = requestDto.Name,
                RegionImageUrl = requestDto.RegionImageUrl
            };

            var regionsDto = new RegionDto(region.Code, region.Name, region.RegionImageUrl)
            {
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };


            _dbContext.Regions.Add(region);
            _dbContext.SaveChanges();

            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] RegionDto requestDto)
        {
            var region = _dbContext.Regions.Find(id);

            if (region == null)
            {
                return NotFound();
            }

            region.Code = requestDto.Code;
            region.Name = requestDto.Name;
            region.RegionImageUrl = requestDto.RegionImageUrl;

            _dbContext.Regions.Update(region);
            _dbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult Delete([FromRoute] Guid id)
        {
            var region = _dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (region == null)
            {
                return NotFound();
            }

            _dbContext.Regions.Remove(region);
            _dbContext.SaveChanges();

            var regionDto = new RegionDto(region.Code, region.Name, region.RegionImageUrl)
            {
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            }; 

            return Ok();
        }

    }
}
