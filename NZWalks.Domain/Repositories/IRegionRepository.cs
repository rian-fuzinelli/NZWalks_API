using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZWalks.Domain.Models;

namespace NZWalks.Domain.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region> GetById(Guid id);
        Task<Region> CreateAsync(Region region);
        Task<Region> UpdateAsync(Region region);
        Task<Region> Remove(Guid Id);
    }
}
