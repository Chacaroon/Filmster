﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Filmster.ViewModels.Actors;
using Filmster.ViewModels.Genres;
using Filmster.ViewModels.Producers;

namespace Filmster.ViewModels.Films
{
	public class FilmViewModel
	{
		public string Title { get; set; }
		public int Year { get; set; }
		public string Description { get; set; }
		public byte Rating { get; set; }
		public string URI { get; set; }
		public TimeSpan Duration { get; set; }

		public IEnumerable<GenreViewModel> Genres { get; set; }
		public IEnumerable<ActorViewModel> Actors { get; set; }
		public IEnumerable<ProducerViewModel> Producers { get; set; }
	}
}
