using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZWalks.Domain.Models;
using NZWalks.Domain.Repositories;
using NZWalks.Infrastructure.Services;

namespace NZWalks.Domain.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionService _regionService;

        public RegionService(IRegionService regionService) 
        {
            _regionService = regionService;
        }

        public async Task<Region> CreateAsync(Region region)
        {
            var regions = await _regionService.GetById(region.Id);
            
            if (regions == null)
            {
                throw new Exception($"There's not a region with the id" + region.Id);
            }

            return await _regionService.CreateAsync(regions);
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _regionService.GetAllAsync();
        }

        public async Task<Region> GetById(Guid Id)
        {
            var regions = await _regionService.GetById(Id) ?? throw new Exception("There's not a region with the id" + Id);

            return regions;
        }
        
        public async Task<Region> UpdateAsync(Region region)
        {
            var regions = await _regionService.GetById(region.Id);
                {
                if (regions == null)
                    throw new Exception($"There's not a region with the id {region.Id}");

                return await _regionService.UpdateAsync(region);
            }
        }

        public async Task<Region> Remove(Guid Id)
        {
            var regions = await _regionService.GetById(Id);
            {
                if (regions == null)
                {
                    throw new Exception($"There's not a region with the id Id {Id}");
                }
                return await _regionService.Remove(Id);
            }
        }
    }
}
