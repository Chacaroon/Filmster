using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.IoC
{
	public static class MapperBootstrapper
	{
		public static void Bootstrap(MapperConfigurationExpression cfg)
		{
			DAL.IoC.MapperBootstrapper.Bootstrap(cfg);
		}
	}
}
