﻿using System.ComponentModel.DataAnnotations;

namespace BussinessObject.Models
{
	public class Comment : BaseModel
    {
        public string CommentHeader { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentTime { get; set; }
        public Guid ArticleId { get; set; }
        public Guid UserId { get; set; }

        public Article Article { get; set; }
        public User User { get; set; }
    }
}