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
	class UserNameFilter : Filter<IQueryable<Film>>
	{
		public override IQueryable<Film> Handle(ref IQueryable<Film> filmsQuery, IFilmsFilters filters)
		{
			if (!filters.UserName.IsNullOrEmpty())
				filmsQuery = FilterByUserName(filmsQuery, filters.UserName);

			return base.Handle(ref filmsQuery, filters);
		}

		private IQueryable<Film> FilterByUserName(IQueryable<Film> filmsQuery, string userName)
			=> filmsQuery.Where(f => f.User.NormalizedUserName == userName.ToUpper());
	}
}
