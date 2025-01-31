using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZWalks.Application.DTOs;

namespace NZWalks.Application.Commands
{
    public record RegionUpdateCommand(string Code, string Name, string RegionImageUrl)
    {
    }
}
