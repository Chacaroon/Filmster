using DAL.Entities;
using SharedKernel.Abstractions.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
	public class ActorRepository : Repository<Actor>, IRepository<Actor>
	{
		public ActorRepository(ApplicationContext dbContext) 
			: base(dbContext)
		{
		}
	}
}
