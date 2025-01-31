using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZWalks.Domain.Models;

namespace NZWalks.Infrastructure.Services
{
    public interface IRegionService
    {
        Task<List<Region>> GetAllAsync();
        Task<Region> GetById(Guid id);
        Task<Region> CreateAsync(Region region);
        Task<Region> UpdateAsync(Region region);
        Task<Region> Remove(Guid Id);
    }
}
