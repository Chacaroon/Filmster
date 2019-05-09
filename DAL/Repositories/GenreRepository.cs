using DAL.Entities;
using SharedKernel.Abstractions.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
	public class GenreRepository : Repository<Genre>
	{
		public GenreRepository(ApplicationContext dbContext) 
			: base(dbContext)
		{
		}
	}
}
