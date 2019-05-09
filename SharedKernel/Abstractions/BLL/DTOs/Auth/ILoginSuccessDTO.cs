using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Abstractions.BLL.DTOs.Auth
{
	public interface ILoginSuccessDTO
	{
		string UserName { get; set; }
		string AccessToken { get; set; }
	}
}
