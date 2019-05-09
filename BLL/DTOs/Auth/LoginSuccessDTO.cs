using System;
using System.Collections.Generic;
using System.Text;
using SharedKernel.Abstractions.BLL.DTOs.Auth;

namespace BLL.DTOs.Auth
{
	public class LoginSuccessDTO : ILoginSuccessDTO
	{
		public string UserName { get; set; }
		public string AccessToken { get; set; }

		public LoginSuccessDTO(string userName, string accessToken)
		{
			UserName = userName;
			AccessToken = accessToken;
		}
	}
}
