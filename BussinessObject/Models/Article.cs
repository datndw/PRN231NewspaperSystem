using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinessObject.Models
{
	public class Article : BaseModel
	{
		public string Title { get; set; }
		public string ShortDescription { get; set; }
		public string ArticleContent { get; set; }
		public string UrlSlug { get; set; }
		public bool IsPublished { get; set; }
		public int ViewCount { get; set; }
		public DateTime PostedOn { get; set; }
		public DateTime? DateModified { get; set; }
		public Guid UserId { get; set; }

        public ICollection<ArticleCategory> ArticleCategories { get; set; }
        public ICollection<Comment> Comments { get; set; }
		public User User { get; set; }
	}
}