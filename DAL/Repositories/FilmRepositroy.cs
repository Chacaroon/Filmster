using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using SharedKernel.Abstractions.DAL.Repositories;

namespace DAL.Repositories
{
	public class FilmRepositroy : Repository<Film>, IRepository<Film>
	{
		public FilmRepositroy(ApplicationContext dbContext) 
			: base(dbContext)
		{
		}
	}
}
