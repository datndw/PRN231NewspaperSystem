using System;
namespace BussinessObject.DTOs
{
	public class UserDTO : BaseModelDTO
	{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string About { get; set; }
    }
}

