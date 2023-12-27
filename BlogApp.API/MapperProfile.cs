using AutoMapper;
using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Business.DTOs.CourseDTOs;
using BlogApp.Business.DTOs.StudentDTOs;
using BlogApp.Business.DTOs.TeacherDTOs;
using BlogApp.Core.Entities;
using System;
using System.ComponentModel;

namespace BlogApp.API
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            
            // Category Section
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>();

            CreateMap<Category, ReadCategoryDTO>()
                .ForMember(dest => dest.ChildCategories, opt => opt.MapFrom(src => src.ChildCategories))
                .ForMember(dest => dest.ParentCategory, opt => opt.MapFrom(src => src.ParentCategory));
            CreateMap<Category, ReadCategoryDTO>().ReverseMap()
                .ForMember(dest => dest.ChildCategories, opt => opt.MapFrom(src => src.ChildCategories))
                .ForMember(dest => dest.ParentCategory, opt => opt.MapFrom(src => src.ParentCategory));

            CreateMap<Category, MiniReadCategoryDTO>().ReverseMap();
            CreateMap<Category, MiniReadCategoryDTO>();

            CreateMap<Category, DetailCategoryDTO>()
                .ReverseMap()
                .ForMember(dest => dest.ChildCategories, opt => opt.MapFrom(src => src.ChildCategories))
                .ForMember(dest => dest.ParentCategory, opt => opt.MapFrom(src => src.ParentCategory));

            CreateMap<Category, DetailCategoryDTO>()
                .ForMember(dest => dest.ChildCategories, opt => opt.MapFrom(src => src.ChildCategories))
                .ForMember(dest => dest.ParentCategory, opt => opt.MapFrom(src => src.ParentCategory));



            // Student Section
            CreateMap<Student, CreateStudentDTO>().ReverseMap();
            CreateMap<Student, CreateStudentDTO>();
            CreateMap<Student, UpdateStudentDTO>().ReverseMap();
            CreateMap<Student, UpdateStudentDTO>();
            CreateMap<Student, ReadStudentDTO>().ReverseMap();
            CreateMap<Student, ReadStudentDTO>();

            // Teahcer Section
            CreateMap<Teacher, CreateTeacherDTO>().ReverseMap();
            CreateMap<Teacher, CreateTeacherDTO>();
            CreateMap<Teacher, UpdateTeacherDTO>().ReverseMap();
            CreateMap<Teacher, UpdateTeacherDTO>();
            CreateMap<Teacher, ReadTeacherDTO>().ReverseMap();
            CreateMap<Teacher, ReadTeacherDTO>();

            // Course Section
            CreateMap<Course, CreateCourseDTO>().ReverseMap();
            CreateMap<Course, CreateCourseDTO>();
            CreateMap<Course, UpdateCourseDTO>().ReverseMap();
            CreateMap<Course, UpdateCourseDTO>();
            CreateMap<Course, ReadCourseDTO>().ReverseMap();
            CreateMap<Course, ReadCourseDTO>();

        }

    }
}