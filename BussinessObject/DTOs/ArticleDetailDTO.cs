using System;
namespace BussinessObject.DTOs
{
	public class ArticleDetailDTO
	{
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ArticleContent { get; set; }
        public string UrlSlug { get; set; }
        public bool IsPublished { get; set; }
        public int ViewCount { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime? DateModified { get; set; }
        public string WriterName { get; set; }
        public List<CategoryDTO> Categories { get; set; }
        public List<CommentDetailDTO> Comments { get; set; }
    }
}

