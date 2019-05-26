using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filmster.ViewModels.Actors;
using Filmster.ViewModels.Directors;
using Filmster.ViewModels.Genres;

namespace Filmster.ViewModels.Filters
{
	public class FiltersViewModel
	{
		public IEnumerable<DirectorViewModel> Directors { get; set; }
		public IEnumerable<GenreViewModel> Genres { get; set; }
		public IEnumerable<ActorViewModel> Actors { get; set; }
	}
}
