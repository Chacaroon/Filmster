using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Filmster.IoC.Profiles;

namespace Filmster.IoC
{
	public static class MapperBootstrapper
	{
		public static void Bootstrap(MapperConfigurationExpression cfg)
		{
			cfg.AddProfile<FilmMappingProfile>();

			BLL.IoC.MapperBootstrapper.Bootstrap(cfg);
		}
	}
}
