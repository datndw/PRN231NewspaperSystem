using System;
namespace BussinessObject.DTOs
{
	public class CommentCreateDTO
	{
        public string CommentHeader { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentTime { get; set; }
        public Guid ArticleId { get; set; }
        public Guid UserId { get; set; }
    }
}

