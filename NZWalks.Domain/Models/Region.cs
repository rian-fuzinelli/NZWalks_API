using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZWalks.Domain.Models
{
    public class RegionEntity
    {
        public Guid Id { get; protected set; }

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string RegionImageUrl { get; set; } = string.Empty;
    }
}
