using System;
namespace BussinessObject.Models
{
	public class ArticleCategory
	{
		public Guid ArticleId { get; set; }
		public Guid CategoryId { get; set; }

		public Article Article { get; set; }
		public Category Category { get; set; }
	}
}

