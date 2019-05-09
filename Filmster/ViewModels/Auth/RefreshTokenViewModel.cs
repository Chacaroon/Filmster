using SharedKernel.Abstractions.BLL.DTOs.Auth;
using System.ComponentModel.DataAnnotations;

namespace Filmster.ViewModels.Auth
{
	public class RefreshTokenViewModel : IRefreshTokenDTO
	{
		[Required(ErrorMessage = "USER_NAME_IS_REQUIRED")]
		public string UserName { get; set; }
		[Required(ErrorMessage = "ACCESS_TOKEN_IS_REQUIRED")]
		public string AccessToken { get; set; }
	}
}
