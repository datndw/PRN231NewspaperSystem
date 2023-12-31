﻿using System;
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

        [HttpGet("Search/{keyword}")]
        public async Task<ActionResult<List<ArticleDTO>>> Get(string? keyword)
        {
            List<Article> articles = new();
            if (keyword == null || keyword.Trim() == "")
            {
                articles = _unitOfWork.ArticleRepository.GetAll().ToList();
            }
            else
            {
                articles = _unitOfWork.ArticleRepository.GetByKeyword(keyword).ToList();
            }
            
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

        [HttpGet("Details/{id}")]
        public async Task<ActionResult<ArticleDetailDTO>> GetDetails(Guid id)
        {
            Article article = _unitOfWork.ArticleRepository.GetArticleDetails(id);
            article.ViewCount += 1;
            _unitOfWork.ArticleRepository.Update(article);
            ArticleDetailDTO response = _mapper.Map<ArticleDetailDTO>(article);
            return Ok(response);
        }

        [HttpGet("ByCategory/{id}")]
        public async Task<ActionResult<List<ArticleDTO>>> GetArticleByCategory(Guid id)
        {
            List<Article> articles = _unitOfWork.ArticleRepository.GetArticlesByCategory(id).ToList();
            List<ArticleDTO> response = _mapper.Map<List<ArticleDTO>>(articles);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<ActionResult<ArticleCreateDTO>> Post([FromBody] ArticleCreateDTO articleCreateDTO)
        {
            Article article = _mapper.Map<ArticleCreateDTO, Article>(articleCreateDTO);
            _unitOfWork.ArticleRepository.Insert(article);
            await _unitOfWork.SaveAsync();
            return Ok(articleCreateDTO);
        }

        [HttpPut]
        [Authorize(Roles = "Writer")]
        public async Task<ActionResult> Put([FromBody] ArticleDTO articleDTO)
        {
            Article article = _mapper.Map<ArticleDTO, Article>(articleDTO);
            _unitOfWork.ArticleRepository.Update(article);
            await _unitOfWork.SaveAsync();
            return Ok(articleDTO);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Writer")]
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

