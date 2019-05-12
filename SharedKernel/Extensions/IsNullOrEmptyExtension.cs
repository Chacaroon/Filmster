using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Extensions
{
	public static class IsNullOrEmptyExtension
	{
		public static bool IsNullOrEmpty(this object item) => item == null;

		public static bool IsNullOrEmpty(this IEnumerable item) => 
			item == null
			|| !item.GetEnumerator().MoveNext();

		public static bool IsNullOrEmpty(this string item) => string.IsNullOrEmpty(item);
	}
}
