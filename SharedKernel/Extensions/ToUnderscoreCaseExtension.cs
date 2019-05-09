using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedKernel.Extensions
{
	public static class ToUnderscoreCaseExtension
	{
		public static string ToUnderscore(this string str)
		{
			return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToUpper();
		}
	}
}
