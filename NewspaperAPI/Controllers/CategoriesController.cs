using System;
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
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoriesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> Get()
        {
            List<Category> categories = _unitOfWork.CategoryRepository.GetAll().ToList();
            List<CategoryDTO> response = _mapper.Map<List<CategoryDTO>>(categories);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> Get(Guid id)
        {
            Category category = _unitOfWork.CategoryRepository.Find(id);
            CategoryDTO response = _mapper.Map<CategoryDTO>(category);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<CategoryDTO>> Post([FromBody] CategoryDTO categoryDTO)
        {
            Category category = _mapper.Map<CategoryDTO, Category>(categoryDTO);
            _unitOfWork.CategoryRepository.Insert(category);
            await _unitOfWork.SaveAsync();
            return Ok(categoryDTO);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Put([FromBody] CategoryDTO categoryDTO)
        {
            Category category = _mapper.Map<CategoryDTO, Category>(categoryDTO);
            _unitOfWork.CategoryRepository.Update(category);
            await _unitOfWork.SaveAsync();
            return Ok(categoryDTO);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(Guid id)
        {
            Category category = _unitOfWork.CategoryRepository.Find(id);
            if (category == null)
            {
                return NotFound("Category Not Found!");
            }
            _unitOfWork.CategoryRepository.DeleteById(id);
            await _unitOfWork.SaveAsync();
            return Ok();
        }
    }
}

