using DAL.Entities;
using SharedKernel.Abstractions.BLL.Services.Filters;
using SharedKernel.Abstractions.PL.ViewModels.Films;
using SharedKernel.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services.FilmFilterService.Filters
{
	class ActorsFilter : Filter<IQueryable<Film>>
	{
		public override IQueryable<Film> Handle(ref IQueryable<Film> filmsQuery, IFilmsFilters filters)
		{
			if (!filters.ActorIds.IsNullOrEmpty())
				filmsQuery = filterByActors(filmsQuery, filters.ActorIds);

			return base.Handle(ref filmsQuery, filters);
		}

		private IQueryable<Film> filterByActors(IQueryable<Film> filmsQuery, IEnumerable<long> actorIds)
		{
			var filmIds = filmsQuery
						  .Select(f => new
						  {
							  f.Id,
							  ActorIds = f.FilmActors.Select(fg => fg.ActorId).ToList()
						  })
						  .ToList()
						  .Where(f => actorIds.All(ai => f.ActorIds.Contains(ai)))
						  .Select(f => f.Id);

			return filmsQuery.Where(f => filmIds.Contains(f.Id));
		}
	}
}
