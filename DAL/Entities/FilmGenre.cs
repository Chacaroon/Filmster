using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DAL.Entities
{
    public class FilmGenre
    {
	    public long FilmId { get; set; }
	    public Film Film { get; set; }

	    public long GenreId { get; set; }
	    public Genre Genre { get; set; }

		public override bool Equals(object obj) => GetHashCode() == obj?.GetHashCode();

		public override int GetHashCode() => $"{FilmId}{GenreId}".GetHashCode();
	}
}
