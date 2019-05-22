using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Entities;
using SharedKernel.Abstractions.BLL.Services.Filters;
using SharedKernel.Abstractions.PL.ViewModels.Films;
using SharedKernel.Extensions;

namespace BLL.Services.FilmFilterService.Filters
{
	class GenresFilter : Filter<IQueryable<Film>>
	{
		public override IQueryable<Film> Handle(ref IQueryable<Film> filmsQuery, IFilmsFilters filters)
		{
			if (!filters.GenreIds.IsNullOrEmpty())
				filmsQuery = FilterByGenres(filmsQuery, filters.GenreIds);

			return base.Handle(ref filmsQuery, filters);
		}

		private IQueryable<Film> FilterByGenres(IQueryable<Film> filmsQuery, IEnumerable<long> genreIds)
		{
			var filmIds = filmsQuery
						  .Select(f => new
						  {
							  f.Id,
							  GenreIds = f.FilmGenres.Select(fg => fg.GenreId).ToList()
						  })
						  .ToList()
						  .Where(f => genreIds.All(gi => f.GenreIds.Contains(gi)))
						  .Select(f => f.Id);

			return filmsQuery.Where(f => filmIds.Contains(f.Id));
		}
	}
}
