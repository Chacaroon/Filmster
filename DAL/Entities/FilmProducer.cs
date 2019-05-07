using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class FilmProducer
    {
	    public long FilmId { get; set; }
	    public Film Film { get; set; }

	    public long ProducerId { get; set; }
	    public Producer Producer { get; set; }
    }
}
