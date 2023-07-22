﻿using System;
namespace BussinessObject.DTOs
{
	public class ArticleCreateDTO
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
    }
}

