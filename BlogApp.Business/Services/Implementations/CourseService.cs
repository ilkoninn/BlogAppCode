using AutoMapper;
using BlogApp.Business.DTOs.CourseDTOs;
using BlogApp.Business.Exceptions.Common;
using BlogApp.Business.Services.Intefaces;
using BlogApp.Core.Entities;
using BlogApp.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Implementations
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
            //if (entity is null) throw new CourseNullException();

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

        public async Task<ICollection<ReadCourseDTO>> ReadAsync(Expression<Func<Course, bool>>? expression = null, Expression<Func<Course, object>>? expressionOrder = null, bool isDescending = false, params string[] includes)
        {
            var result = await _rep.ReadAsync();

            return _mapper.Map<ICollection<ReadCourseDTO>>(result);
        }

        public async Task<ReadCourseDTO> ReadAsync(int Id)
        {
            if (Id <= 0 || Id == null) throw new NegativeIdException();

            var result = await _rep.ReadAsync(Id);

            //if (result is null) throw new CourseNotFoundException();


            return _mapper.Map<ReadCourseDTO>(result);
        }

        public async Task<Course> UpdateAsync(UpdateCourseDTO entity, string env)
        {
            if (entity.Id <= 0 || entity.Id == null) throw new NegativeIdException();

            Course oldCourse = await _rep.ReadAsync(entity.Id);

            //if (oldCourse is null) throw new CourseNotFoundException();

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

            Course oldCourse = await _rep.ReadAsync(Id);

            //if (oldCourse is null) throw new CourseNotFoundException();


            await _rep.DeleteAsync(oldCourse);
            await _rep.SaveChangesAsync();

            return oldCourse;
        }
    }
}
