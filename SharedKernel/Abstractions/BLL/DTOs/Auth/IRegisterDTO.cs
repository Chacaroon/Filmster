using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Abstractions.BLL.DTOs.Auth
{
	public interface IRegisterDTO
	{
		string UserName { get; set; }
		string Password { get; set; }
	}
}
