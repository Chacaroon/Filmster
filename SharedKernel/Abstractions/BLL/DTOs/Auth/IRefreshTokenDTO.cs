using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Abstractions.BLL.DTOs.Auth
{
	public interface IRefreshTokenDTO
	{
		string UserName { get; set; }
		string AccessToken { get; set; }
	}
}
