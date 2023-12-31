﻿using AutoMapper;
using BlogApp.Business.DTOs.CourseDTOs;
using BlogApp.Business.DTOs.StudentDTOs;
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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _rep;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository rep, IMapper mapper)
        {
            _rep = rep;
            _mapper = mapper;
        }

        public async Task<Student> CreateAsync(CreateStudentDTO entity, string env)
        {
            if (entity is null) throw new ObjectNullException();

            Student newStudent = new()
            {
                Name = entity.Name,
                Surname = entity.Surname,
                Age = entity.Age,
                UpdatedDate = DateTime.Now,
                CreatedDate = DateTime.Now
            };

            var result = await _rep.CreateAsync(newStudent);
            await _rep.SaveChangesAsync();

            return result;
        }

        public async Task<ICollection<ReadStudentDTO>> ReadAsync()
        {
            var result = await _rep.ReadAsync();

            var query = _mapper.Map<ICollection<ReadStudentDTO>>(result.Include(x => x.Courses).ToList());

            return query;
        }

        public async Task<DetailStudentDTO> ReadIdAsync(int Id)
        {
            if (Id <= 0 || Id == null) throw new NegativeIdException();

            var result = await _rep.ReadIdAsync(Id, entityIncludes: "Courses");

            if (result is null) throw new ObjectNotFoundException();


            return _mapper.Map<DetailStudentDTO>(result);
        }

        public async Task<Student> UpdateAsync(UpdateStudentDTO entity, string env)
        {
            if (entity.Id <= 0 || entity.Id == null) throw new NegativeIdException();

            Student oldStudent = await _rep.ReadIdAsync(entity.Id);

            if (oldStudent is null) throw new ObjectNotFoundException();

            oldStudent.Name = entity.Name;
            oldStudent.Surname = entity.Surname;
            oldStudent.Age = entity.Age;
            oldStudent.UpdatedDate = DateTime.Now;
            oldStudent.CreatedDate = oldStudent.CreatedDate;

            var result = await _rep.UpdateAsync(oldStudent);
            await _rep.SaveChangesAsync();

            return result;
        }

        public async Task<Student> DeleteAsync(int Id)
        {
            if (Id <= 0 || Id == null) throw new NegativeIdException();

            Student oldStudent = await _rep.ReadIdAsync(Id);

            if (oldStudent is null) throw new ObjectNotFoundException();


            await _rep.DeleteAsync(Id);
            await _rep.SaveChangesAsync();

            return oldStudent;
        }
    }
}
