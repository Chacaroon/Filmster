using System.Threading.Tasks;
using AutoMapper;
using Filmster.ViewModels;
using Filmster.ViewModels.Auth;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Abstractions.BLL.DTOs.Auth;
using SharedKernel.Abstractions.BLL.Services;
using SharedKernel.Abstractions.PL.ViewModels.Auth;
using SharedKernel.Exceptions;

namespace Filmster.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		[HttpPost("Login")]
		public async Task<ActionResult<ILoginSuccessViewModel>> Login([FromBody] LoginViewModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			ILoginSuccessViewModel res;

			try
			{
				res = Mapper.Map<ILoginSuccessViewModel>(await _authService.LoginAsync(Mapper.Map<ILoginDTO>(model)));
			}
			catch (UserNotFoundException e)
			{
				return NotFound(new ExceptionViewModel(e.Message));
			}
			catch (IncorrectPasswordException e)
			{
				return BadRequest(new ExceptionViewModel(e.Message));
			}

			return Ok(res);
		}

		[HttpPost("Register")]
		public async Task<ActionResult<ILoginSuccessViewModel>> Register([FromBody] RegisterViewModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			ILoginSuccessViewModel res;

			try
			{
				res = Mapper.Map<ILoginSuccessViewModel>(
					await _authService.RegisterAsync(Mapper.Map<IRegisterDTO>(model)));
			}
			catch (UserNotRegisteredException e)
			{
				return BadRequest(new ExceptionViewModel(e.Message));
			}

			return Ok(res);
		}

		[HttpPost("RefreshToken")]
		public async Task<ActionResult<ILoginSuccessViewModel>> RefreshToken([FromBody] RefreshTokenViewModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			ILoginSuccessViewModel res;

			try
			{
				res = Mapper.Map<ILoginSuccessViewModel>(
					await _authService.RefreshTokenAsync(Mapper.Map<IRefreshTokenDTO>(model)));
			}
			catch (RefreshTokenException e)
			{
				return BadRequest(e.Message);
			}

			return Ok(res);
		}
	}
}