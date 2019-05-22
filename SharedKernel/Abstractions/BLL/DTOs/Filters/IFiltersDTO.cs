using SharedKernel.Abstractions.BLL.DTOs.Actors;
using SharedKernel.Abstractions.BLL.DTOs.Genres;
using SharedKernel.Abstractions.BLL.DTOs.Producers;
using System.Collections.Generic;

namespace SharedKernel.Abstractions.BLL.DTOs.Filters
{
	public interface IFiltersDTO
	{
		IEnumerable<IGenreDTO> Genres { get; set; }
		IEnumerable<IActorDTO> Actors { get; set; }
		IEnumerable<IProducerDTO> Producers { get; set; }
	}
}
