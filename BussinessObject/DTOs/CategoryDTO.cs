using System;
namespace BussinessObject.DTOs
{
	public class CategoryDTO : BaseModelDTO
	{
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string Description { get; set; }
    }
}

