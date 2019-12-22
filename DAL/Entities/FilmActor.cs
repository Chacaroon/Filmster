using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
	public class FilmActor
	{
		public long FilmId { get; set; }
		public Film Film { get; set; }

		public long ActorId { get; set; }
		public Actor Actor { get; set; }

		public override bool Equals(object obj) => GetHashCode() == obj?.GetHashCode();

		public override int GetHashCode() => $"{FilmId}{ActorId}".GetHashCode();
	}
}
