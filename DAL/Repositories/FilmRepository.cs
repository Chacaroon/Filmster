using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Abstractions.DAL.Repositories;

namespace DAL.Repositories
{
	public class FilmRepository : Repository<Film>
	{
		public FilmRepository(ApplicationContext dbContext)
			: base(dbContext)
		{
		}

		public override IQueryable<Film> GetAll() =>
			base.GetAll()
				.Include(f => f.User)
			    .Include(f => f.FilmGenres)
			    .ThenInclude(fg => fg.Genre)
			    .Include(f => f.FilmActors)
			    .ThenInclude(fa => fa.Actor)
			    .Include(f => f.FilmProducers)
			    .ThenInclude(fp => fp.Producer);
	}
}
