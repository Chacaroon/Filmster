using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Abstractions.PL.ViewModels.Auth
{
	public interface IRegisterViewModel
	{
		string UserName { get; set; }
		string Password { get; set; }
	}
}
