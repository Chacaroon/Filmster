using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Abstractions.PL.ViewModels.Auth
{
	public interface ILoginViewModel
	{
		string UserName { get; set; }
		string Password { get; set; }
	}
}
