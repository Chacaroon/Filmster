using SharedKernel.Abstractions.BLL.DTOs.Actors;
using SharedKernel.Abstractions.BLL.DTOs.Directors;
using SharedKernel.Abstractions.BLL.DTOs.Genres;
using SharedKernel.Abstractions.BLL.DTOs.Users;
using System;
using System.Collections.Generic;

namespace SharedKernel.Abstractions.BLL.DTOs.Films
{
	public interface IFilmDTO
	{
		long Id { get; set; }
		string Title { get; set; }
		int Year { get; set; }
		string Description { get; set; }
		byte Rating { get; set; }
		string URI { get; set; }
		TimeSpan Duration { get; set; }
		IUserDTO User { get; set; }

		IDirectorDTO Director { get; set; }
		IEnumerable<IGenreDTO> Genres { get; set; }
		IEnumerable<IActorDTO> Actors { get; set; }
	}
}
