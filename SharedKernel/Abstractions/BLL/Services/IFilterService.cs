using System;
using System.Collections.Generic;
using System.Text;
using SharedKernel.Abstractions.BLL.DTOs.Filters;

namespace SharedKernel.Abstractions.BLL.Services
{
	public interface IFilterService
	{
		IEnumerable<IFilterDTO> SearchFilters(string filter, string value);
	}
}
