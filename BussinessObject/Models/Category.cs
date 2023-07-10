using System.ComponentModel.DataAnnotations;

namespace BussinessObject.Models
{
	public class Category : BaseModel
    {
        [Required(ErrorMessage = "Category name is required")]
        [StringLength(255, ErrorMessage = "Name must be shorter than 255 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Url slug name must be required")]
        [StringLength(255, ErrorMessage = "Url slug must be shorter than 255 characters")]
        public string UrlSlug { get; set; }

        [StringLength(1024, ErrorMessage = "Description must be shorter than 1024 characters")]
        public string Description { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}