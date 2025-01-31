using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZWalks.Application.DTOs;

namespace NZWalks.Application.Commands
{
    public record RegionDeleteCommand(Guid Id)
    {
    }
}
