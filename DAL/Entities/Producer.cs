using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Producer : Entity
    {
	    public Producer()
	    {
		    FilmProducers = new List<FilmProducer>();
	    }

	    public Producer(string name)
			: base()
	    {
		    Name = name;
	    }

	    public string Name { get; set; }

	    public IEnumerable<FilmProducer> FilmProducers { get; set; }
    }
}
