using DAL.Entities;
using SharedKernel.Abstractions.BLL.Services.Filters;
using SharedKernel.Abstractions.PL.ViewModels.Films;
using SharedKernel.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services.FilmFilterService.Filters
{
	class ProducersFilter : Filter<IQueryable<Film>>
	{
		public override IQueryable<Film> Handle(IQueryable<Film> filmsQuery, IFilmsFilters filters)
		{
			if (!filters.ProducerIds.IsNullOrEmpty())
				filmsQuery = FilterByProducers(filmsQuery, filters.ProducerIds);

			return base.Handle(filmsQuery, filters);
		}

		private IQueryable<Film> FilterByProducers(IQueryable<Film> filmsQuery, IEnumerable<long> producerIds)
		{
			var filmIds = filmsQuery
						  .Select(f => new
						  {
							  f.Id,
							  ProducerIds = f.FilmProducers.Select(fg => fg.ProducerId).ToList()
						  })
						  .ToList()
						  .Where(f => producerIds.All(ai => f.ProducerIds.Contains(ai)))
						  .Select(f => f.Id);

			return filmsQuery.Where(f => filmIds.Contains(f.Id));
		}
	}
}
