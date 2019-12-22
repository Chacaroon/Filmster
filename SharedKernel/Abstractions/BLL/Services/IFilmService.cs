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
		IFilmsResponseDTO GetAll(IFilmsFilters filters, string orderBy, string searchString, int page = 1);
		IFilmDTO GetById(long id);
		Task<long> Add(IAddFilmDTO dto);
		void Update(IUpdateFilmDTO dto);
		void Delete(long id);
	}
}
