using SharedKernel.Abstractions.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedKernel.Abstractions.DAL.Repositories
{
	public interface IRepository<T> where T : IEntity
	{
		IQueryable<T> GetAll();
		IQueryable<T> GetAll(Func<T, bool> predicate);
		T FindById(long id);
		void Add(T item);
		void AddRange(IEnumerable<T> item);
		void Update(T item);
		void Delete(T item);
		void DeleteById(long id);
		void DeleteRange(IEnumerable<T> item);
	}
}
