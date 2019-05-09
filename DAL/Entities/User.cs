using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace DAL.Entities
{
	public class User : IdentityUser<long>
	{
		public User()
		{
			Films = new List<Film>();
		}

		public User(string userName)
			: base()
		{
			UserName = userName;
		}

		public IEnumerable<Film> Films { get; set; }
	}
}
