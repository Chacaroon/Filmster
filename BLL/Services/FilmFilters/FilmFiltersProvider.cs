using System.Linq;
using BLL.Services.FilmFilterService.Filters;
using DAL.Entities;
using SharedKernel.Abstractions.BLL.Services.Filters;
using SharedKernel.Abstractions.PL.ViewModels.Films;

namespace BLL.Services.FilmFilters
{
	static class FilmFiltersProvider
	{
		public static void FilterFilms(ref IQueryable<Film> filmsQuery, IFilmsFilters filters)
		{
			Filter<Film> filtersPipeline = new GenresFilter();

			//filtersPipeline
			//	.SetNextFilter(new ActorsFilter())
			//	.SetNextFilter(new DirectorFilter())
			//	.SetNextFilter(new UserNameFilter());

			filtersPipeline.Handle(ref filmsQuery, filters);
		}
	}
}
