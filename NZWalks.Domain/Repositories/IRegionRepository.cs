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
        Task<IEnumerable<RegionEntity>> GetAllAsync();
        Task<RegionEntity> GetById(Guid id);
        Task<RegionEntity> CreateAsync(RegionEntity region);
        Task<RegionEntity> UpdateAsync(Guid id, RegionEntity region);
        Task<RegionEntity> Remove(Guid id);
    }
}
