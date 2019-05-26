using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Filmster.ViewModels.Films
{
	public class AddFilmViewModel
	{
		public string Title { get; set; }
		public int Year { get; set; }
		public string Description { get; set; }
		public byte Rating { get; set; }
		public string URI { get; set; }
		public string Duration { get; set; }

		public long DirectorId { get; set; }
		public IEnumerable<long> GenreIds { get; set; }
		public IEnumerable<long> ActorIds { get; set; }
	}
}
