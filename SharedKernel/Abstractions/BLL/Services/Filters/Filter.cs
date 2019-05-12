using System.Linq;
using SharedKernel.Abstractions.PL.ViewModels.Films;
using SharedKernel.Extensions;

namespace SharedKernel.Abstractions.BLL.Services.Filters
{
	public abstract class Filter<T> 
		where T : IQueryable
	{
		protected Filter<T> NextFilter { get; set; }

		public Filter<T> SetNextFilter(Filter<T> filter)
		{
			NextFilter = filter;

			return filter;
		}

		public virtual T Handle(T filmsQuery, IFilmsFilters filters)
		{
			if (!NextFilter.IsNullOrEmpty())
				return NextFilter.Handle(filmsQuery, filters);

			return filmsQuery;
		}
	}
}
