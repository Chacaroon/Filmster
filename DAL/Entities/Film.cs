using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
	public class Film : Entity
	{
		public string Title { get; set; }
		public int Year { get; set; }
		public string Description { get; set; }
		public byte Rating { get; set; }
		public string URI { get; set; }
		public TimeSpan Duration { get; set; }

		public IEnumerable<FilmGenre> FilmGenres { get; set; }
		public IEnumerable<FilmActor> FilmActors { get; set; }
		public IEnumerable<FilmProducer> FilmProducers { get; set; }
	}
}
