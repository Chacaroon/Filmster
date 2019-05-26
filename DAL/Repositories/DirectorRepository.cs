using DAL.Entities;
using SharedKernel.Abstractions.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
	public class ProducerRepository : Repository<Director>
	{
		public ProducerRepository(ApplicationContext dbContext) 
			: base(dbContext)
		{
		}
	}
}
