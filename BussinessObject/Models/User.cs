﻿using System;
using Microsoft.AspNetCore.Identity;

namespace BussinessObject.Models
{
	public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
		public DateTime BirthDate { get; set; }
		public string? About { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual ICollection<Article>? Articles { get; set; }
    }
}

