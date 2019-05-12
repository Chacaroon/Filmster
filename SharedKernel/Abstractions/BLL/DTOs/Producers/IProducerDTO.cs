using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Abstractions.BLL.DTOs.Producers
{
	public interface IProducerDTO
	{
		long Id { get; set; }
		string Name { get; set; }
	}
}
