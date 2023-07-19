using System;
namespace BussinessObject.Models
{
	public class ArticleCategory
	{
		public Guid ArticleId { get; set; }
		public Guid CategoryId { get; set; }

		public virtual Article Article { get; set; }
		public virtual Category Category { get; set; }
	}
}

