using System;
using System.Collections.Generic;
using System.Text;
using SharedKernel.Abstractions.BLL.DTOs.Actors;

namespace BLL.DTOs.Filters
{
	class ActorDTO : IActorDTO
	{
		public long Id { get; set; }
		public string Name { get; set; }

		public override bool Equals(object obj) => GetHashCode() == obj?.GetHashCode();

		public override int GetHashCode() => Id.GetHashCode();
	}
}
