﻿using System;
namespace BussinessObject.Models
{
	public class RegistrationRequest
	{
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
