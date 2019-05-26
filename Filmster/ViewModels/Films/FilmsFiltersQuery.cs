using SharedKernel.Abstractions.PL.ViewModels.Films;
using System.Collections.Generic;

namespace Filmster.ViewModels.Films
{
	public class FilmsFiltersQuery : IFilmsFilters
	{
		public string UserName { get; set; }

		public IEnumerable<long> GenreIds { get; set; }
		public IEnumerable<long> ActorIds { get; set; }
		public long DirectorId { get; set; }
	}
}
