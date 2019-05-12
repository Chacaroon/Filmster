using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using BLL.IoC.Profiles;

namespace BLL.IoC
{
	public static class MapperBootstrapper
	{
		public static void Bootstrap(MapperConfigurationExpression cfg)
		{
			cfg.AddProfile<FilmMappingProfile>();

			DAL.IoC.MapperBootstrapper.Bootstrap(cfg);
		}
	}
}
