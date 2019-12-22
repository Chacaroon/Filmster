using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Repositories;
using SharedKernel.Abstractions.DAL.Repositories;
using DAL.QueryParams;

namespace DAL.IoC
{
	public static class Bootstrapper
	{
		public static void Bootstrap(Container container)
		{
			container.Register<IRepository<Film, FilmParams>, FilmRepository>();
			container.Register<IRepository<Actor, ActorParams>, ActorRepository>();
			container.Register<IRepository<Director, DirectorParams>, ProducerRepository>();
			container.Register<IRepository<Genre, GenreParams>, GenreRepository>();
		}
	}
}
