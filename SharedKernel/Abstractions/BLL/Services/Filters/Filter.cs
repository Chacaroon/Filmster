using System.Linq;
using SharedKernel.Abstractions.DAL.Entities;
using SharedKernel.Abstractions.PL.ViewModels.Films;
using SharedKernel.Extensions;

namespace SharedKernel.Abstractions.BLL.Services.Filters
{
	public abstract class Filter<T> 
		where T : IEntity
	{
		protected Filter<T> NextFilter { get; set; }

		public Filter<T> SetNextFilter(Filter<T> filter)
		{
			NextFilter = filter;

			return filter;
		}

		public virtual IQueryable<T> Handle(ref IQueryable<T> filmsQuery, IFilmsFilters filters)
		{
			if (!NextFilter.IsNullOrEmpty())
				return NextFilter.Handle(ref filmsQuery, filters);

			return filmsQuery;
		}
	}
}
