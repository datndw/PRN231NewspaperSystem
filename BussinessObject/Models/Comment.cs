using System.ComponentModel.DataAnnotations;

namespace BussinessObject.Models
{
	public class Comment : BaseModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(255, ErrorMessage = "Name must be shorter than 255 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        public Guid ArticleId { get; set; }

        public Article Article { get; set; }

        public string CommentHeader { get; set; }

        public string CommentText { get; set; }

        public DateTime CommentTime { get; set; }
    }
}