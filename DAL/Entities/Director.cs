using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Director : Entity
	{
		public string Name { get; set; }

		public Director(string name)
		{
		    Name = name;
	    }
    }
}
