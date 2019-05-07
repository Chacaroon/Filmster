using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Repositories;
using SharedKernel.Abstractions.DAL.Repositories;

namespace DAL.IoC
{
	public static class Bootstrapper
	{
		public static void Bootstrap(Container container)
		{
			container.Register<IRepository<Film>, FilmRepositroy>();
			container.Register<IRepository<Actor>, ActorRepository>();
			container.Register<IRepository<Producer>, ProducerRepository>();
			container.Register<IRepository<Genre>, GenreRepository>();
		}
	}
}
