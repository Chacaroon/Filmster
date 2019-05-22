using System;
using System.Collections.Generic;
using System.Text;
using SharedKernel.Abstractions.BLL.DTOs.Producers;

namespace BLL.DTOs.Filters
{
	class ProducerDTO : IProducerDTO
	{
		public long Id { get; set; }
		public string Name { get; set; }

		protected bool Equals(ProducerDTO other)
		{
			return Id == other.Id;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((ProducerDTO) obj);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}
	}
}
