using SharedKernel.Abstractions.BLL.DTOs.Directors;

namespace BLL.DTOs.Filters
{
	class DirectorDTO : IDirectorDTO
	{
		public long Id { get; set; }
		public string Name { get; set; }

		protected bool Equals(DirectorDTO other)
		{
			return Id == other.Id;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			return obj.GetType() == this.GetType() && Equals((DirectorDTO)obj);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}
	}
}
