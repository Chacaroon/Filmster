using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Abstractions.BLL.Services
{
	public interface ITokenService
	{
		Task<string> GenerateTokenAsync(string userName);
		Task<string> RefreshTokenAsync(string oldToken, string userName);
	}
}
