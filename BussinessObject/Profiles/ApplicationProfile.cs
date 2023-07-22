using System;
using AutoMapper;
using BussinessObject.DTOs;
using BussinessObject.Models;
using System.Data;
using System.Net;

namespace BussinessObject.Profiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<User, UserDTO>()
                .ReverseMap();
            CreateMap<Comment, CommentDetailDTO>()
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                .ReverseMap();
            CreateMap<Comment, CommentCreateDTO>()
                .ReverseMap();
            CreateMap<Article, ArticleDetailDTO>()
                .ForMember(dest => dest.WriterName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.ArticleCategories.Select(ac => ac.Category).ToList()))
                .ReverseMap();
            CreateMap<Article, ArticleDTO>()
                .ReverseMap();
            CreateMap<Category, CategoryDTO>()
                .ReverseMap();
            CreateMap<Comment, CommentDTO>()
                .ReverseMap();
        }
    }
}

