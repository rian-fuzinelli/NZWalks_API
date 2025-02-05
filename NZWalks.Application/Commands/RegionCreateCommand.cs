using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZWalks.Application.Commands
{
    public record RegionCreateCommand(Guid Id, string Code, string Name, string RegionImageUrl)
    {
    }
}
