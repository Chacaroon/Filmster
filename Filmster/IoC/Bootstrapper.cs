using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleInjector;

namespace Filmster.IoC
{
	public static class Bootstrapper
	{
		public static void Bootstrap(Container container)
		{
			BLL.IoC.Bootstrapper.Bootstrap(container);
		}
	}
}
