using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZWalks.Application.Commands;
using NZWalks.Domain.Repositories;

namespace NZWalks.Application.Handlers
{
    public class RegionDeleteCommandHandler
    {
        private readonly IRegionRepository _regionRepository;

        public RegionDeleteCommandHandler(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task Handler(RegionDeleteCommand command)
        {
            var region = await _regionRepository.GetById(command.Id) ?? throw new Exception("Não existe uma região com o Id " + command.Id);

            await _regionRepository.Remove(region.Id);
        }
    }
}
