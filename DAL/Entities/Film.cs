using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
	public class Film : Entity
	{
		public Film()
		{
			FilmGenres = new List<FilmGenre>();
			FilmActors = new List<FilmActor>();
			FilmProducers =  new List<FilmProducer>();
		}

		public string Title { get; set; }
		public int Year { get; set; }
		public string Description { get; set; }
		public byte Rating { get; set; }
		public string URI { get; set; }
		public TimeSpan Duration { get; set; }

		public long UserId { get; set; }
		public User User { get; set; }
		public IEnumerable<FilmGenre> FilmGenres { get; set; }
		public IEnumerable<FilmActor> FilmActors { get; set; }
		public IEnumerable<FilmProducer> FilmProducers { get; set; }
	}
}
