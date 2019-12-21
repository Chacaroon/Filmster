using DAL.Entities;
using SharedKernel.Abstractions.BLL.Services.Filters;
using SharedKernel.Abstractions.PL.ViewModels.Films;
using SharedKernel.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services.FilmFilterService.Filters
{
	class DirectorFilter : Filter<Film>
	{
		public override IQueryable<Film> Handle(ref IQueryable<Film> filmsQuery, IFilmsFilters filters)
		{
			if (filters.DirectorId != default)
				filmsQuery = FilterByProducers(filmsQuery, filters.DirectorId);

			return base.Handle(ref filmsQuery, filters);
		}

		private IQueryable<Film> FilterByProducers(IQueryable<Film> filmsQuery, long directorId)
		{
			return filmsQuery.Where(f => f.DirectorId == directorId);
		}
	}
}
