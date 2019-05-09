using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SharedKernel.Abstractions.BLL.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using SharedKernel.Exceptions;

namespace BLL.Services
{
	public class TokenService : ITokenService
	{
		private readonly UserManager<User> _userManager;
		private readonly IConfiguration _configuration;

		public TokenService(UserManager<User> userManager, IConfiguration configuration)
		{
			_userManager = userManager;
			_configuration = configuration;
		}

		public async Task<string> GenerateTokenAsync(string userName)
		{
			var user = await _userManager.FindByNameAsync(userName);
			ClaimsIdentity identity = await GetIdentity(user);

			var now = DateTime.UtcNow;
			var expires = DateTime.UtcNow.Add(TimeSpan.FromHours(int.Parse(_configuration["AuthOptions:LIFETIME"])));

			var token = new JwtSecurityToken(
				issuer: _configuration["AuthOptions:ISSUER"],
				audience: _configuration["AuthOptions:AUDIENCE"],
				notBefore: now,
				claims: identity.Claims,
				expires: expires,
				signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["AuthOptions:KEY"])), SecurityAlgorithms.HmacSha256));

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		public async Task<string> RefreshTokenAsync(string oldToken, string userName)
		{
			var token = new JwtSecurityTokenHandler().ReadJwtToken(oldToken);

			var tokenUserName = token.Claims
				.Single(x => x.Type == ClaimsIdentity.DefaultNameClaimType)
				.Value;

			if (tokenUserName != userName)
				throw new RefreshTokenException();

			return await GenerateTokenAsync(userName);
		}

		private async Task<ClaimsIdentity> GetIdentity(User user)
		{
			IEnumerable<string> userRoles = await _userManager.GetRolesAsync(user);

			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName)
			};

			userRoles.ToList().ForEach(r => claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, r)));

			return new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
		}
	}
}
