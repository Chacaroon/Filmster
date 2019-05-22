using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Abstractions.BLL.DTOs.Users
{
	public interface IUserDTO
	{
		long Id { get; set; }
		string UserName { get; set; }
	}
}
