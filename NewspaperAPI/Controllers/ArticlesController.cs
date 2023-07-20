using System;
using System.Data;
using AutoMapper;
using BussinessObject.DTOs;
using BussinessObject.Models;
using DataAccess.Infrastructure;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleDTO>> Get(Guid id)
        {
            Article article = _unitOfWork.ArticleRepository.Find(id);
            ArticleDTO response = _mapper.Map<ArticleDTO>(article);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ArticleDTO>> Post([FromBody] ArticleDTO articleDTO)
        {
            Article article = _mapper.Map<ArticleDTO, Article>(articleDTO);
            _unitOfWork.ArticleRepository.Insert(article);
            await _unitOfWork.SaveAsync();
            return Ok(articleDTO);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Put([FromBody] ArticleDTO articleDTO)
        {
            Article article = _mapper.Map<ArticleDTO, Article>(articleDTO);
            _unitOfWork.ArticleRepository.Update(article);
            await _unitOfWork.SaveAsync();
            return Ok(articleDTO);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(Guid id)
        {
            Article article = _unitOfWork.ArticleRepository.Find(id);
            if(article == null)
            {
                return NotFound("Article Not Found!");
            }
            _unitOfWork.ArticleRepository.DeleteById(id);
            await _unitOfWork.SaveAsync();
            return Ok();
        }
    }
}

