using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinessObject.Models
{
	public class Article : BaseModel
	{
		[Required(ErrorMessage = "Title must be required")]
		public string Title { get; set; }

		[StringLength(1024)]
		[Column("Short Description")]
		public string ShortDescription { get; set; }

		[Required(ErrorMessage = "Article content must be required")]
		[Column("Article Content")]
		public string ArticleContent { get; set; }

		[Required(ErrorMessage = "Url slug must be required")]
		public string UrlSlug { get; set; }

		public bool IsPublished { get; set; }

		public int ViewCount { get; set; }

		public DateTime PostedOn { get; set; }

		public DateTime? DateModified { get; set; }

		public Guid CategoryId { get; set; }

		public Category Category { get; set; }

		public ICollection<Comment> Comments { get; set; }
	}
}