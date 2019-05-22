using System;
using System.Collections.Generic;
using System.Text;
using SharedKernel.Abstractions.DAL.Entities;

namespace DAL.Entities
{
	public class Entity : IEntity
	{
		public long Id { get; set; }

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}
	}
}
