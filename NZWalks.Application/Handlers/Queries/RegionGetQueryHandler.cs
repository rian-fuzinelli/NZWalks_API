using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZWalks.Application.Queries;
using NZWalks.Domain.Models;
using NZWalks.Domain.Repositories;

namespace NZWalks.Application.Handlers.Queries
{
    public class RegionGetQueryHandler
    {
        private readonly IRegionRepository _regionRepository;

        public RegionGetQueryHandler(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task<RegionEntity> Handler(RegionGetByIdQuery request, CancellationToken cancellationToken)
        {
            var regions = await _regionRepository.GetById(request.Id);

            return regions;
        }
    }
}
