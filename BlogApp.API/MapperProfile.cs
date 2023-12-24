using AutoMapper;
using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Core.Entities;
using System.ComponentModel;

namespace BlogApp.API
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>();
            CreateMap<UpdateCategoryDTO, Category>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>();
        }

    }
}