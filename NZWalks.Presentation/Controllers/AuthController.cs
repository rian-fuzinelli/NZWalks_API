using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NZWalks.Domain.Models;
using NZWalks.Domain.Repositories;

namespace NZWalks.Presentation.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IRegionRepository _regionRepository;

        public AuthController(IConfiguration configuration, IRegionRepository regionRepository)
        {
            _configuration = configuration;
            _regionRepository = regionRepository;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] RegionEntity region)
        {
            var regions = _regionRepository.GetAllAsync();

            if (regions == null)
            {
                return Unauthorized(new { message = "Invalid Credentials" }); 
            }
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, region.Name),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var accessToken = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: creds);

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtAccessToken = tokenHandler.WriteToken(accessToken);

            var refreshToken = Guid.NewGuid().ToString();

            return Ok(new { accessToken =  jwtAccessToken, refreshToken});
        }

    }
}
