using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NZWalks.Application.Commands
{
    public record RegionUpdateCommand(Guid Id, string Code, string Name, string RegionImageUrl) : IRequest<bool>
    {
    }
}
