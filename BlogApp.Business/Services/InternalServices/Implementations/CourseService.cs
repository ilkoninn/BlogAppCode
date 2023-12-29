using AutoMapper;
using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Business.DTOs.CourseDTOs;
using BlogApp.Business.DTOs.TeacherDTOs;
using BlogApp.Business.Exceptions.Common;
using BlogApp.Business.Services.InternalServices.Intefaces;
using BlogApp.Core.Entities;
using BlogApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.InternalServices.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _rep;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository rep, IMapper mapper)
        {
            _rep = rep;
            _mapper = mapper;
        }

        public async Task<Course> CreateAsync(CreateCourseDTO entity, string env)
        {
            if (entity is null) throw new ObjectNullException();

            Course newCourse = new()
            {
                Title = entity.Title,
                Description = entity.Description,
                TeacherId = entity.TeacherId,
                UpdatedDate = DateTime.Now,
                CreatedDate = DateTime.Now
            };

            var result = await _rep.CreateAsync(newCourse);
            await _rep.SaveChangesAsync();

            return result;
        }

        public async Task<ICollection<ReadCourseDTO>> ReadAsync()
        {
            var result = await _rep.ReadAsync();

            var query = _mapper.Map<ICollection<ReadCourseDTO>>(result
                .Include(x => x.Teacher)
                .Include(x => x.Students));

            return query;
        }

        public async Task<DetailCourseDTO> ReadIdAsync(int Id)
        {
            if (Id <= 0 || Id == null) throw new NegativeIdException();

            var result = await _rep.ReadIdAsync(Id, entityIncludes: ["Teacher", "Students"]);

            if (result is null) throw new ObjectNotFoundException();


            return _mapper.Map<DetailCourseDTO>(result);
        }

        public async Task<Course> UpdateAsync(UpdateCourseDTO entity, string env)
        {
            if (entity.Id <= 0 || entity.Id == null) throw new NegativeIdException();

            Course oldCourse = await _rep.ReadIdAsync(entity.Id);

            if (oldCourse is null) throw new ObjectNotFoundException();

            oldCourse.Title = entity.Title;
            oldCourse.Description = entity.Description;
            oldCourse.UpdatedDate = DateTime.Now;
            oldCourse.CreatedDate = oldCourse.CreatedDate;

            var result = await _rep.UpdateAsync(oldCourse);
            await _rep.SaveChangesAsync();

            return result;
        }

        public async Task<Course> DeleteAsync(int Id)
        {
            if (Id <= 0 || Id == null) throw new NegativeIdException();

            Course oldCourse = await _rep.ReadIdAsync(Id);

            if (oldCourse is null) throw new ObjectNotFoundException();


            await _rep.DeleteAsync(Id);
            await _rep.SaveChangesAsync();

            return oldCourse;
        }
    }
}
