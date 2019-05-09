using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Exceptions
{
	public class IncorrectPasswordException : ApplicationException
	{
		public IncorrectPasswordException()
			: base("INCORRECT_PASSWORD")
		{ }
	}
}
