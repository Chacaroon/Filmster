using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Filmster.ViewModels.Actors;
using Filmster.ViewModels.Directors;
using Filmster.ViewModels.Genres;
using Filmster.ViewModels.User;

namespace Filmster.ViewModels.Films
{
	public class FilmViewModel
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public int Year { get; set; }
		public string Description { get; set; }
		public byte Rating { get; set; }
		public string URI { get; set; }
		public TimeSpan Duration { get; set; }
		public UserViewModel User { get; set; }

		public DirectorViewModel Director { get; set; }
		public IEnumerable<GenreViewModel> Genres { get; set; }
		public IEnumerable<ActorViewModel> Actors { get; set; }
	}
}
