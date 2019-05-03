using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.IoC
{
	public static class Bootstrapper
	{
		public static void Bootstrap(Container container)
		{
			DAL.IoC.Bootstrapper.Bootstrap(container);
		}
	}
}
