using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NZWalks.Domain.Models;

namespace NZWalks.Application.Queries
{
    public record RegionGetAllQuery : IRequest<List<RegionEntity>>
    {
    }
}
