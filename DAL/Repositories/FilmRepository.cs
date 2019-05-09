using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using SharedKernel.Abstractions.DAL.Repositories;

namespace DAL.Repositories
{
	public class FilmRepository : Repository<Film>
	{
		public FilmRepository(ApplicationContext dbContext) 
			: base(dbContext)
		{
		}
	}
}
