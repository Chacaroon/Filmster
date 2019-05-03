using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;

namespace Filmster.IoC
{
	public static class MapperBootstrapper
	{
		public static void Bootstrap(MapperConfigurationExpression cfg)
		{
			BLL.IoC.MapperBootstrapper.Bootstrap(cfg);
		}
	}
}
