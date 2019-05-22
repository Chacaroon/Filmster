using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filmster.ViewModels.Actors;
using Filmster.ViewModels.Genres;
using Filmster.ViewModels.Producers;

namespace Filmster.ViewModels.Filters
{
	public class FiltersViewModel
	{
		public IEnumerable<GenreViewModel> Genres { get; set; }
		public IEnumerable<ActorViewModel> Actors { get; set; }
		public IEnumerable<ProducerViewModel> Producers { get; set; }
	}
}
