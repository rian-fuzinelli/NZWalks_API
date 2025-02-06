using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NZWalks.Domain.Models;
using NZWalks.Domain.Repositories;
using NZWalks.Infrastructure.Data;

namespace NZWalks.Infrastructure.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _dbContext;

        public RegionRepository(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RegionEntity> CreateAsync(RegionEntity region)
        {
            await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<RegionEntity>> GetAllAsync()
        {
            return await _dbContext.Regions.ToListAsync();
        }

        public async Task<RegionEntity> GetById(Guid id)
        {
            return await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<RegionEntity> Remove(Guid id)
        {
            var region = await _dbContext.Regions.FindAsync(id);
            _dbContext.Regions.Remove(region);
            return region;
        }
        public async Task<RegionEntity> UpdateAsync(Guid id, RegionEntity region)
        {
            _dbContext.Regions.Update(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }
    }
}
