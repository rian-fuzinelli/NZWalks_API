using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NZWalks.Domain.Repositories;

namespace NZWalks.Application.Queries
{
    public record RegionGetByIdQuery(Guid Id) : IRequest<IRegionRepository>
    {

    }
}
