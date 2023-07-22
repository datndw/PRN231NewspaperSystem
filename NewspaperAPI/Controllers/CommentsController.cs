using System;
using AutoMapper;
using BussinessObject.DTOs;
using BussinessObject.Models;
using DataAccess.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace NewspaperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CommentsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CommentDTO>>> Get()
        {
            List<Comment> comments = _unitOfWork.CommentRepository.GetAll().ToList();
            List<CommentDTO> response = _mapper.Map<List<CommentDTO>>(comments);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDTO>> Get(Guid id)
        {
            Comment comment = _unitOfWork.CommentRepository.Find(id);
            CommentDTO response = _mapper.Map<CommentDTO>(comment);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<CommentCreateDTO>> Post([FromBody] CommentCreateDTO commentCreateDTO)
        {
            Comment comment = _mapper.Map<CommentCreateDTO, Comment>(commentCreateDTO);
            _unitOfWork.CommentRepository.Insert(comment);
            await _unitOfWork.SaveAsync();
            return Ok(commentCreateDTO);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Put([FromBody] CommentDTO commentDTO)
        {
            Comment comment = _mapper.Map<CommentDTO, Comment>(commentDTO);
            _unitOfWork.CommentRepository.Update(comment);
            await _unitOfWork.SaveAsync();
            return Ok(commentDTO);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(Guid id)
        {
            Comment comment = _unitOfWork.CommentRepository.Find(id);
            if (comment == null)
            {
                return NotFound("Comment Not Found!");
            }
            _unitOfWork.CommentRepository.DeleteById(id);
            await _unitOfWork.SaveAsync();
            return Ok();
        }
    }
}

