using System.ComponentModel.DataAnnotations;

namespace BussinessObject.Models
{
	public class Comment : BaseModel
    {
        public string CommentHeader { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentTime { get; set; }
        public Guid ArticleId { get; set; }
        public Guid UserId { get; set; }

        public virtual Article Article { get; set; }
        public virtual User User { get; set; }
    }
}