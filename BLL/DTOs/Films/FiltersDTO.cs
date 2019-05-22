using System;
using System.Collections.Generic;
using System.Text;
using SharedKernel.Abstractions.BLL.DTOs.Actors;
using SharedKernel.Abstractions.BLL.DTOs.Filters;
using SharedKernel.Abstractions.BLL.DTOs.Genres;
using SharedKernel.Abstractions.BLL.DTOs.Producers;

namespace BLL.DTOs.Films
{
	class FiltersDTO : IFiltersDTO
	{
		public IEnumerable<IGenreDTO> Genres { get; set; }
		public IEnumerable<IActorDTO> Actors { get; set; }
		public IEnumerable<IProducerDTO> Producers { get; set; }
	}
}
