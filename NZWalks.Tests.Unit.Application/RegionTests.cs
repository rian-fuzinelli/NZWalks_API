using Moq;
using NZWalks.API.Controllers;
using NZWalks.Domain.Models;
using NZWalks.Domain.Repositories;
using NZWalks.Domain.Services;
using NZWalks.Infrastructure.Repositories;
using Xunit;

namespace NZWalks.Tests.Unit
{
    public class RegionTests
    {
        private readonly Mock<IRegionRepository> _regionRepositoryMock;
        private readonly RegionService _regionService;

        public RegionTests()
        {
            _regionRepositoryMock = new Mock<IRegionRepository>();
            _regionService = new RegionService(_regionRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllRegions()
        {
            // Arrange
            var regions = new List<RegionEntity>
            {
                new RegionEntity { Code = "BER", Name = "Berlim", RegionImageUrl = "www.berlim.de" }
            };

            _regionRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(regions);

            var result = await _regionService.GetAllAsync();

            Assert.NotNull(result); 
            Assert.IsType<List<RegionEntity>>(result);
            Assert.Equal("Berlim", result.First().Name);
        }
    }
}
