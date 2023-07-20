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
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {
            List<User> users = _unitOfWork.UserRepository.GetAll().ToList();
            List<UserDTO> response = _mapper.Map<List<UserDTO>>(users);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(Guid id)
        {
            User user = _unitOfWork.UserRepository.Find(id);
            UserDTO response = _mapper.Map<UserDTO>(user);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserDTO userDTO)
        {
            User user = _mapper.Map<UserDTO, User>(userDTO);
            _unitOfWork.UserRepository.Insert(user);
            await _unitOfWork.SaveAsync();
            return Ok(userDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserDTO userDTO)
        {
            User user = _mapper.Map<UserDTO, User>(userDTO);
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveAsync();
            return Ok(userDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            User user = _unitOfWork.UserRepository.Find(id);
            if (user == null)
            {
                return NotFound("User Not Found!");
            }
            _unitOfWork.UserRepository.DeleteById(id);
            await _unitOfWork.SaveAsync();
            return Ok();
        }
    }
}

