using System;
using AutoMapper;
using BussinessObject.DTOs;
using BussinessObject.Models;
using DataAccess.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace NewspaperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public ArticlesController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

        [HttpGet]
        public async Task<ActionResult<List<ArticleDTO>>> Get()
        {
            List<Article> articles = _unitOfWork.ArticleRepository.GetAll().ToList();
            List<ArticleDTO> response = _mapper.Map<List<ArticleDTO>>(articles);
            return Ok(response);
        }
    }
}

