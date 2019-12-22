using SharedKernel.Abstractions.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedKernel.Abstractions.DAL.Repositories
{
	public interface IRepository<T, TParams> 
		where T : IEntity
		where TParams : class
	{
		IQueryable<T> GetAll(TParams @params = null);
		T FindById(long id);
		void Add(T item);
		void AddRange(IEnumerable<T> item);
		void Update(T item);
		void Delete(T item);
		void DeleteById(long id);
		void DeleteRange(IEnumerable<T> item);
	}
}
