using System.Collections.Generic;

namespace Filmster.ViewModels
{
	public class ExceptionViewModel
	{
		public Dictionary<string, IEnumerable<string>> Errors { get; }

		public ExceptionViewModel(string message)
		{
			Errors = new Dictionary<string, IEnumerable<string>> { { "_", new[] { message } } };
		}
	}
}
