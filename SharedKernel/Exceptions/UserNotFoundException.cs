using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Exceptions
{
	public class UserNotFoundException : ApplicationException
	{
		public UserNotFoundException()
			: base("USER_NOT_FOUND")
		{ }
	}
}
