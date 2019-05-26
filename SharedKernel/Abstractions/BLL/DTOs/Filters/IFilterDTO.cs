using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Abstractions.BLL.DTOs.Filters
{
	public interface IFilterDTO
	{
		long Id { get; set; }
		string Name { get; set; }
	}
}
