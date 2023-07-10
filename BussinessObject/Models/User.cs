using System;
using Microsoft.AspNetCore.Identity;

namespace BussinessObject.Models
{
	public class User : IdentityUser<Guid>
    {
		public DateTime BirthDate { get; set; }
		public string About { get; set; }
	}
}

