using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Abstractions.BLL.DTOs.Genres
{
	public interface IGenreDTO
	{
		long Id { get; set; }
		string Name { get; set; }
	}
}
