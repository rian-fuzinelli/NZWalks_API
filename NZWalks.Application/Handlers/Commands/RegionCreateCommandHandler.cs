using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NZWalks.Application.Commands;
using NZWalks.Domain.Models;
using NZWalks.Domain.Repositories;

namespace NZWalks.Application.Handlers
{
    public class RegionCreateCommandHandler : IRequest<RegionCreateCommand>
    {
        private readonly IRegionRepository _regionRepository;

        public RegionCreateCommandHandler(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task<string> HandleAsync(RegionCreateCommand request, CancellationToken cancellationToken)
        {
            var region = new RegionEntity
            {
                Code = request.Code,
                Name = request.Name,
                RegionImageUrl = request.RegionImageUrl
            };

            await _regionRepository.CreateAsync(region);
            return region.Code;
        }
    }
}
