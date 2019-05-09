using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Exceptions
{
	public class UserNotRegisteredException : ApplicationException
	{
		public UserNotRegisteredException()
			: base("USER_NOT_REGISTERED")
		{ }

		public UserNotRegisteredException(string message) 
			: base(message)
		{ }
	}
}
