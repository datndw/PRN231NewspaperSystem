using System;
namespace BussinessObject.DTOs
{
	public class UserDTO : BaseModelDTO
	{
        public DateTime BirthDate { get; set; }
        public string About { get; set; }
    }
}

