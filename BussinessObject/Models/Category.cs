using System.ComponentModel.DataAnnotations;

namespace BussinessObject.Models
{
	public class Category : BaseModel
    {
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<ArticleCategory> ArticleCategories { get; set; }
    }
}