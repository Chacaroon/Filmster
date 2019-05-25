using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Abstractions.BLL.DTOs.Films
{
	public interface IUpdateFilmDTO
	{
		long Id { get; set; }
		string Title { get; set; }
		int Year { get; set; }
		string Description { get; set; }
		byte Rating { get; set; }
		string URI { get; set; }
		string Duration { get; set; }

		long DirectorId { get; set; }
		IEnumerable<long> GenreIds { get; set; }
		IEnumerable<long> ActorIds { get; set; }
	}
}
