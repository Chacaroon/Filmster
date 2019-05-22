using System.ComponentModel.DataAnnotations;

namespace Filmster.ViewModels.Auth
{
	public class RegisterViewModel
	{

		[Required(ErrorMessage = "USER_NAME_IS_REQUIRED")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "PASSWORD_IS_REQUIRED")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
