using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NZWalks.Domain.Models;
using NZWalks.Domain.Repositories;
using NZWalks.Domain.Services;
using NZWalks.Infrastructure.Repositories;

namespace NZWalks.CrossCutting.IoC
{
    public static class IocExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<RegionService>();
        }

        public static void AddRepositories(this IServiceCollection services) 
        {
            services.AddScoped<IRegionRepository, RegionRepository>();

        }
    }
}
