using System;
using Microsoft.EntityFrameworkCore;
using NZWalks.Domain.Models;
using NZWalks.Domain.Repositories;

namespace NZWalks.Infrastructure.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<RegionEntity> Regions { get; set; }

    }
}
