using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZWalks.Domain.Models;
using NZWalks.Domain.Repositories;
using NZWalks.Infrastructure.Data;

namespace NZWalks.Infrastructure.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly IRegionRepository _regionRepository;

        public RegionRepository(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }
        public virtual async Task<Region> CreateAsync(Region region)
        {
            await _regionRepository.CreateAsync(region);
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _regionRepository.GetAllAsync();
        }

        public async Task<Region> GetById(Guid id)
        {
            return await _regionRepository.GetById(id);
        }

        public Task<Region> Remove(Guid Id)
        {
           return _regionRepository.Remove(Id);
        }

        public virtual async Task<Region> UpdateAsync(Guid id, Region region)
        {
            return await _regionRepository.UpdateAsync(id, region);
        }
    }
}
