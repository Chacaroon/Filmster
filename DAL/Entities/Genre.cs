using System;
using System.Collections.Generic;
using System.Text;
using SharedKernel.Abstractions.DAL.Entities;

namespace DAL.Entities
{
	public class Genre : Entity
	{
		public string Name { get; set; }

		public IEnumerable<FilmGenre> FilmGenres { get; set; }
	}
}
