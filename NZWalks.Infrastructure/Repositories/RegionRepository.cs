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

        public async Task<Region> CreateAsync(Region region)
        {
            await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _dbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetById(Guid id)
        {
           return await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Region> Remove(Guid id)
        {
            var region = await _dbContext.Regions.FindAsync(id);
            if (region == null)
            {
                throw new Exception("There's not a region with the id" + id);
            }

            _dbContext.Regions.Remove(region);
            await _dbContext.SaveChangesAsync();

            return region;
        }
        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            _dbContext.Regions.Update(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }
    }
}
