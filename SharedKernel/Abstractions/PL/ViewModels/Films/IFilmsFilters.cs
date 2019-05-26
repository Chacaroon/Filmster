using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Abstractions.PL.ViewModels.Films
{
	public interface IFilmsFilters
	{
		string UserName { get; set; }

		IEnumerable<long> GenreIds { get; set; }
		IEnumerable<long> ActorIds { get; set; }
		long DirectorId { get; set; }
	}
}
