using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Exceptions
{
	public class RefreshTokenException : ApplicationException
	{
		public RefreshTokenException()
			: base("REFRESH_TOKEN_EXCEPTION")
		{ }
	}
}
