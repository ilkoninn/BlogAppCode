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

            // Read Category Section
            CreateMap<Category, ReadCategoryDTO>();
            CreateMap<Category, ReadCategoryDTO>().ReverseMap();

            CreateMap<Category, MiniReadCategoryDTO>().ReverseMap();
            CreateMap<Category, MiniReadCategoryDTO>();

            CreateMap<Category, DetailCategoryDTO>().ReverseMap();
            CreateMap<Category, DetailCategoryDTO>();

            // Student Section
            CreateMap<Student, CreateStudentDTO>().ReverseMap();
            CreateMap<Student, CreateStudentDTO>();
            CreateMap<Student, UpdateStudentDTO>().ReverseMap();
            CreateMap<Student, UpdateStudentDTO>();
            
            // Read Student Section
            CreateMap<Student, ReadStudentDTO>().ReverseMap();
            CreateMap<Student, ReadStudentDTO>();

            CreateMap<Student, MiniReadStudentDTO>().ReverseMap();
            CreateMap<Student, MiniReadStudentDTO>();

            CreateMap<Student, DetailStudentDTO>().ReverseMap();
            CreateMap<Student, DetailStudentDTO>();

            CreateMap<Student, MiniDetailStudentDTO>().ReverseMap();
            CreateMap<Student, MiniDetailStudentDTO>();

            // Teahcer Section
            CreateMap<Teacher, CreateTeacherDTO>().ReverseMap();
            CreateMap<Teacher, CreateTeacherDTO>();
            CreateMap<Teacher, UpdateTeacherDTO>().ReverseMap();
            CreateMap<Teacher, UpdateTeacherDTO>();
            
            // Read Teacher Section
            CreateMap<Teacher, ReadTeacherDTO>().ReverseMap();
            CreateMap<Teacher, ReadTeacherDTO>();

            CreateMap<Teacher, MiniReadTeacherDTO>().ReverseMap();
            CreateMap<Teacher, MiniReadTeacherDTO>();
            
            CreateMap<Teacher, DetailTeacherDTO>().ReverseMap();
            CreateMap<Teacher, DetailTeacherDTO>();



            // Course Section
            CreateMap<Course, CreateCourseDTO>().ReverseMap();
            CreateMap<Course, CreateCourseDTO>();
            CreateMap<Course, UpdateCourseDTO>().ReverseMap();
            CreateMap<Course, UpdateCourseDTO>();

            // Read Student Section
            CreateMap<Course, ReadCourseDTO>().ReverseMap();
            CreateMap<Course, ReadCourseDTO>();

            CreateMap<Course, MiniReadCourseDTO>().ReverseMap();
            CreateMap<Course, MiniReadCourseDTO>();

            CreateMap<Course, DetailCourseDTO>().ReverseMap();
            CreateMap<Course, DetailCourseDTO>();

        }

    }
}