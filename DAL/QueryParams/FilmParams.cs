using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.QueryParams
{
	public class FilmParams
	{
		public string Title { get; set; }
		public IEnumerable<long> GenresFilter { get; set; } = new List<long>();
		public IEnumerable<long> ActorsFilter { get; set; } = new List<long>();
		public IEnumerable<long> DirectorsFilter { get; set; } = new List<long>();
	}
}
