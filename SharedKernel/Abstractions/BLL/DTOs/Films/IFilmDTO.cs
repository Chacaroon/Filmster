﻿using System;
using System.Collections.Generic;
using System.Text;
using SharedKernel.Abstractions.BLL.DTOs.Actors;
using SharedKernel.Abstractions.BLL.DTOs.Genres;
using SharedKernel.Abstractions.BLL.DTOs.Producers;

namespace SharedKernel.Abstractions.BLL.DTOs.Films
{
	public interface IFilmDTO
	{
		string Title { get; set; }
		int Year { get; set; }
		string Description { get; set; }
		byte Rating { get; set; }
		string URI { get; set; }
		TimeSpan Duration { get; set; }

		IEnumerable<IGenreDTO> Genres { get; set; }
		IEnumerable<IActorDTO> Actors { get; set; }
		IEnumerable<IProducerDTO> Producers { get; set; }
	}
}
