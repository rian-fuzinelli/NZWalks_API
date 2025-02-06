using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZWalks.Domain.Models;
using NZWalks.Domain.Repositories;
namespace NZWalks.Domain.Services
{
    public class RegionService
    {
        private readonly IRegionRepository _regionRepository;

        public RegionService(IRegionRepository regionRepository) 
        {
            _regionRepository = regionRepository;
        }

        public async Task<RegionEntity> CreateAsync(RegionEntity region)
        {
          var regions = new RegionEntity();
            region.Name = region.Name;
            region.Code = region.Code;
            region.RegionImageUrl = region.RegionImageUrl;

            return await _regionRepository.CreateAsync(region);
        }

        public async Task<IEnumerable<RegionEntity>> GetAllAsync()
        {
            return await _regionRepository.GetAllAsync();
        }

        public async Task<RegionEntity> GetById(Guid Id)
        {
            var regions = await _regionRepository.GetById(Id) ?? throw new Exception("There's not a region with the id" + Id);

            return regions;
        }
        
        public async Task<RegionEntity> UpdateAsync(Guid id, RegionEntity region)
        {
            var regions = await _regionRepository.GetById(id);
                if (regions == null)
                    throw new Exception($"There's not a region with the id {region.Id}");

                return await _regionRepository.UpdateAsync(id, region);
        }

        public async Task<RegionEntity> Remove(Guid Id)
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
