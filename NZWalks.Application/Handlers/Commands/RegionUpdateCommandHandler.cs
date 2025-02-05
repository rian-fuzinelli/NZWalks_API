using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZWalks.Application.Commands;
using NZWalks.Domain.Repositories;

namespace NZWalks.Application.Handlers
{
    public class RegionUpdateCommandHandler
    {
        private readonly IRegionRepository _regionRepository;

        public RegionUpdateCommandHandler(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }
        
        public async Task<bool> Handle(RegionUpdateCommand request, CancellationToken cancellationToken)
        {
            var region = await _regionRepository.GetById(request.Id);

            if (region == null)
            {
                return false;
            }

            region.Code = request.Code;
            region.Name = request.Name;
            region.RegionImageUrl = request.RegionImageUrl;

            await _regionRepository.UpdateAsync(request.Id, region);
            return true;
        }
    }
}
