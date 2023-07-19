using System.ComponentModel.DataAnnotations;

namespace BussinessObject.Models
{
	public abstract class BaseModel
	{
		public Guid Id { get; set; }
	}
}