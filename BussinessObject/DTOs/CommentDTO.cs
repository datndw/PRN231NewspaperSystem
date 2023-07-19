using System;
namespace BussinessObject.DTOs
{
	public class CommentDTO : BaseModelDTO
	{
        public string CommentHeader { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentTime { get; set; }
    }
}

