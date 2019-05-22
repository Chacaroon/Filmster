using System;
using System.Collections.Generic;
using System.Text;
using SharedKernel.Abstractions.DAL.Entities;

namespace DAL.Entities
{
	public class Genre : Entity, IEquatable<Genre>
	{
		public string Name { get; set; }

		public IEnumerable<FilmGenre> FilmGenres { get; set; }

		public Genre()
		{
			FilmGenres = new List<FilmGenre>();
		}

		public Genre(string name)
			: base()
		{
			Name = name;
		}


		public bool Equals(Genre other)
		{
			return Id == other.Id;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Genre) obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}
