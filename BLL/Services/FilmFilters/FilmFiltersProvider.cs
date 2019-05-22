using System.Linq;
using BLL.Services.FilmFilterService.Filters;
using DAL.Entities;
using SharedKernel.Abstractions.BLL.Services.Filters;
using SharedKernel.Abstractions.PL.ViewModels.Films;

namespace BLL.Services.FilmFilters
{
	static class FilmFiltersProvider
	{
		public static IQueryable<Film> FilterFilms(ref IQueryable<Film> filmsQuery, IFilmsFilters filters)
		{
			Filter<IQueryable<Film>> filtersPipeline = new GenresFilter();

			filtersPipeline
				.SetNextFilter(new ActorsFilter())
				.SetNextFilter(new ProducersFilter())
				.SetNextFilter(new UserNameFilter());

			return filtersPipeline.Handle(ref filmsQuery, filters);
		}
	}
}
