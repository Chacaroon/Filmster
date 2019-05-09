using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
	public class Actor : Entity
	{
		public Actor()
		{
			FilmActors = new List<FilmActor>();
		}

		public Actor(string name)
			: base()
		{
			Name = name;
		}

		public string Name { get; set; }

		public IEnumerable<FilmActor> FilmActors { get; set; }
	}
}
