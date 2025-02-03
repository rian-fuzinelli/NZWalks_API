using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZWalks.Domain.Models;
using NZWalks.Domain.Repositories;
namespace NZWalks.Domain.Services
{
    public class RegionService : IRegionRepository
    {
        private readonly IRegionRepository _regionRepository;

        public RegionService(IRegionRepository regionRepository) 
        {
            _regionRepository = regionRepository;
        }

        public async Task<Region> CreateAsync(Region region)
        {
          var regions = new Region();
            region.Name = region.Name;
            region.Code = region.Code;
            region.RegionImageUrl = region.RegionImageUrl;

            return await _regionRepository.CreateAsync(region);
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _regionRepository.GetAllAsync();
        }

        public async Task<Region> GetById(Guid Id)
        {
            var regions = await _regionRepository.GetById(Id) ?? throw new Exception("There's not a region with the id" + Id);

            return regions;
        }
        
        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var regions = await _regionRepository.GetById(id);
                if (regions == null)
                    throw new Exception($"There's not a region with the id {region.Id}");

                return await _regionRepository.UpdateAsync(id, region);
        }

        public async Task<Region> Remove(Guid Id)
        {
            var regions = await _regionRepository.GetById(Id);
            {
                if (regions == null)
                {
                    throw new Exception($"There's not a region with the id Id {Id}");
                }
                return await _regionRepository.Remove(Id);
            }
        }
    }
}
