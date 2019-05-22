using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filmster.ViewModels.Filters;

namespace Filmster.ViewModels.Films
{
	public class FilmsResponseViewModel
	{
		public IEnumerable<FilmViewModel> Films { get; set; }

		public FiltersViewModel Filters { get; set; }
	}
}
