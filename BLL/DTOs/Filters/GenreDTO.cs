using System;
using System.Collections.Generic;
using System.Text;
using SharedKernel.Abstractions.BLL.DTOs.Genres;

namespace BLL.DTOs.Filters
{
	public class GenreDTO : IGenreDTO, IEquatable<GenreDTO>
	{
		public long Id { get; set; }
		public string Name { get; set; }

		public bool Equals(GenreDTO other)
		{
			return other.Id == Id;
		}
	}
}
