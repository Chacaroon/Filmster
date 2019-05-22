using System;
using System.Collections.Generic;
using System.Text;
using SharedKernel.Abstractions.BLL.DTOs.Filters;

namespace SharedKernel.Abstractions.BLL.DTOs.Films
{
	public interface IFilmsResponseDTO
	{
		IEnumerable<IFilmDTO> Films { get; set; }
		IFiltersDTO Filters { get; set; }
	}
}
