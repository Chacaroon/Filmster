using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SharedKernel.Abstractions.PL.ViewModels;
using SharedKernel.Abstractions.PL.ViewModels.Auth;

namespace Filmster.ViewModels.Auth
{
	public class RegisterViewModel : IRegisterViewModel
	{
		
		[Required(ErrorMessage = "USER_NAME_IS_REQUIRED")]
		public string UserName { get; set; }
		
		[Required(ErrorMessage = "PASSWORD_IS_REQUIRED")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
