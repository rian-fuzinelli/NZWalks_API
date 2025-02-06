using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZWalks.Domain.Models;
using NZWalks.Domain.Repositories;

namespace NZWalks.Application.Handlers.Queries
{
    public class RegionGetAllQueryHandler
    {
        private readonly IRegionRepository _regionRepository;

        public RegionGetAllQueryHandler(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task<List<RegionEntity>> Handler()
        {
            var regions = await _regionRepository.GetAllAsync();

            return regions.ToList();
        }
    }
}
