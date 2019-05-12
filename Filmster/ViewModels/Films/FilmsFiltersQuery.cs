using System.Collections.Generic;
using SharedKernel.Abstractions.PL.ViewModels.Films;

namespace Filmster.ViewModels.Films
{
	public class FilmsFiltersQuery : IFilmsFilters
	{
		public string UserName { get; set; }

		public IEnumerable<long> GenreIds { get; set; }
		public IEnumerable<long> ActorIds { get; set; }
		public IEnumerable<long> ProducerIds { get; set; }
	}
}
