using DAL.Entities;
using DAL.QueryParams;
using SharedKernel.Abstractions.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
	public class GenreRepository : Repository<Genre, GenreParams>
	{
		public GenreRepository(ApplicationContext dbContext) 
			: base(dbContext)
		{
		}
	}
}
