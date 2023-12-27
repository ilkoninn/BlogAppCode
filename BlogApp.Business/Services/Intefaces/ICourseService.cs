using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Business.DTOs.CourseDTOs;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Intefaces
{
    public interface ICourseService
    {
        Task<ICollection<ReadCourseDTO>> ReadAsync();
        Task<ReadCourseDTO> ReadAsync(int Id);
        Task<Course> CreateAsync(CreateCourseDTO entity, string env);
        Task<Course> UpdateAsync(UpdateCourseDTO entity, string env);
        Task<Course> DeleteAsync(int Id);
    }
}
