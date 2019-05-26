using SharedKernel.Abstractions.BLL.DTOs.Actors;
using SharedKernel.Abstractions.BLL.DTOs.Directors;
using SharedKernel.Abstractions.BLL.DTOs.Genres;
using System.Collections.Generic;

namespace SharedKernel.Abstractions.BLL.DTOs.Filters
{
	public interface IFiltersDTO
	{
		IEnumerable<IDirectorDTO> Directors { get; set; }
		IEnumerable<IGenreDTO> Genres { get; set; }
		IEnumerable<IActorDTO> Actors { get; set; }
	}
}
