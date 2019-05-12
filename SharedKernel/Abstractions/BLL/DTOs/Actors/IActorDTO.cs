using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Abstractions.BLL.DTOs.Actors
{
	public interface IActorDTO
	{
		long Id { get; set; }
		string Name { get; set; }
	}
}
