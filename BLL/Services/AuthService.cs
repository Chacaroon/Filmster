using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs.Auth;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using SharedKernel.Abstractions.BLL.DTOs.Auth;
using SharedKernel.Abstractions.BLL.Services;
using SharedKernel.Abstractions.PL.ViewModels;
using SharedKernel.Exceptions;
using SharedKernel.Extensions;

namespace BLL.Services
{
	public class AuthService : IAuthService
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly ITokenService _tokenService;

		public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_tokenService = tokenService;
		}

		public async Task<ILoginSuccessDTO> LoginAsync(ILoginDTO dto)
		{
			var user = await _userManager.FindByNameAsync(dto.UserName);

			if (user == null)
				throw new UserNotFoundException();

			var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

			if (!result.Succeeded)
				throw new IncorrectPasswordException();

			var accessToken = await _tokenService.GenerateTokenAsync(user.UserName);

			return new LoginSuccessDTO(user.UserName, accessToken);
		}

		public async Task<ILoginSuccessDTO> RegisterAsync(IRegisterDTO dto)
		{
			var user = new User(dto.UserName);

			var result = await _userManager.CreateAsync(user, dto.Password);

			if (!result.Succeeded)
			{
				throw new UserNotRegisteredException(result.Errors.First().Code.ToUnderscore());
			}

			var accessToken = await _tokenService.GenerateTokenAsync(user.UserName);

			return new LoginSuccessDTO(user.UserName, accessToken);
		}

		public async Task<ILoginSuccessDTO> RefreshTokenAsync(IRefreshTokenDTO dto)
		{
			var accessToken = await _tokenService.RefreshTokenAsync(dto.AccessToken, dto.UserName);

			return new LoginSuccessDTO(dto.UserName, accessToken);
		}
	}
}
