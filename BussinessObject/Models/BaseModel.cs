using System.ComponentModel.DataAnnotations;

namespace BussinessObject.Models
{
	public abstract class BaseModel
	{
		[Key]
		public Guid Id { get; set; }
	}
}