using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SharedKernel.Abstractions.BLL.DTOs.Films;
using SharedKernel.Abstractions.PL.ViewModels.Films;

namespace SharedKernel.Abstractions.BLL.Services
{
	public interface IFilmService
	{
		IEnumerable<IFilmDTO> GetAll(IFilmsFilters filters, string orderBy);
		IFilmDTO GetById(long id);
		Task<long> Add(IAddFilmDTO dto);
	}
}
