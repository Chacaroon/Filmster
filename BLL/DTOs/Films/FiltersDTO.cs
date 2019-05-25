using SharedKernel.Abstractions.BLL.DTOs.Actors;
using SharedKernel.Abstractions.BLL.DTOs.Filters;
using SharedKernel.Abstractions.BLL.DTOs.Genres;
using System.Collections.Generic;
using SharedKernel.Abstractions.BLL.DTOs.Directors;

namespace BLL.DTOs.Films
{
	class FiltersDTO : IFiltersDTO
	{
		public IEnumerable<IDirectorDTO> Directors { get; set; }
		public IEnumerable<IGenreDTO> Genres { get; set; }
		public IEnumerable<IActorDTO> Actors { get; set; }
	}
}
