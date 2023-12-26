﻿using AutoMapper;
using BlogApp.Business.DTOs.TeacherDTOs;
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
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _rep;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherRepository rep, IMapper mapper)
        {
            _rep = rep;
            _mapper = mapper;
        }

        public async Task<Teacher> CreateAsync(CreateTeacherDTO entity, string env)
        {
            if (entity is null) throw new ObjectNullException();

            Teacher newTeacher = new()
            {
                Name = entity.Name,
                Surname = entity.Surname,
                Age = entity.Age,
                UpdatedDate = DateTime.Now,
                CreatedDate = DateTime.Now
            };

            var result = await _rep.CreateAsync(newTeacher);
            await _rep.SaveChangesAsync();

            return result;
        }

        public async Task<ICollection<ReadTeacherDTO>> ReadAsync(Expression<Func<Teacher, bool>>? expression = null, Expression<Func<Teacher, object>>? expressionOrder = null, bool isDescending = false, params string[] includes)
        {
            var result = await _rep.ReadAsync();

            return _mapper.Map<ICollection<ReadTeacherDTO>>(result);
        }

        public async Task<ReadTeacherDTO> ReadAsync(int Id)
        {
            if (Id <= 0 || Id == null) throw new NegativeIdException();

            var result = await _rep.ReadAsync(Id);

            if (result is null) throw new ObjectNotFoundException();


            return _mapper.Map<ReadTeacherDTO>(result);
        }

        public async Task<Teacher> UpdateAsync(UpdateTeacherDTO entity, string env)
        {
            if (entity.Id <= 0 || entity.Id == null) throw new NegativeIdException();

            Teacher oldTeacher = await _rep.ReadAsync(entity.Id);

            if (oldTeacher is null) throw new ObjectNotFoundException();

            oldTeacher.Name = entity.Name;
            oldTeacher.Surname = entity.Surname;
            oldTeacher.Age = entity.Age;
            oldTeacher.UpdatedDate = DateTime.Now;
            oldTeacher.CreatedDate = oldTeacher.CreatedDate;

            var result = await _rep.UpdateAsync(oldTeacher);
            await _rep.SaveChangesAsync();

            return result;
        }

        public async Task<Teacher> DeleteAsync(int Id)
        {
            if (Id <= 0 || Id == null) throw new NegativeIdException();

            Teacher oldTeacher = await _rep.ReadAsync(Id);

            if (oldTeacher is null) throw new ObjectNotFoundException();


            await _rep.DeleteAsync(oldTeacher);
            await _rep.SaveChangesAsync();

            return oldTeacher;
        }
    }
}