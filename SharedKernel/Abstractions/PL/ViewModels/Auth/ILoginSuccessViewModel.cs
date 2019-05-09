using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Abstractions.PL.ViewModels.Auth
{
	public interface ILoginSuccessViewModel
	{
		string UserName { get; set; }
		string AccessToken { get; set; }
	}
}
