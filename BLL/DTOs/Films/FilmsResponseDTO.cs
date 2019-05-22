using System;
using System.Collections.Generic;
using System.Text;
using SharedKernel.Abstractions.BLL.DTOs.Films;
using SharedKernel.Abstractions.BLL.DTOs.Filters;

namespace BLL.DTOs.Films
{
	class FilmsResponseDTO : IFilmsResponseDTO
	{
		public IEnumerable<IFilmDTO> Films { get; set; }
		public IFiltersDTO Filters { get; set; }
	}
}
