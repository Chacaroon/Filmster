using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class FilmGenre
    {
	    public long FilmId { get; set; }
	    public Film Film { get; set; }

	    public long GenreId { get; set; }
	    public Genre Genre { get; set; }
    }
}
