using AutoMapper;
using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Business.Exceptions;
using BlogApp.Business.Exceptions.CategoryExceptions;
using BlogApp.Business.Exceptions.Common;
using BlogApp.Business.Services.Intefaces;
using BlogApp.Core.Entities;
using BlogApp.DAL.Repositories.Interfaces;
using DianaWebApp.Helper;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _rep;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository rep, IMapper mapper)
        {
            _rep = rep;
            _mapper = mapper;
        }

        public async Task<Category> CreateAsync(CreateCategoryDTO entity, string env)
        {
            if (entity is null) throw new CategoryNullException();

            Category newCategory = new() 
            {
                Name = entity.Name,
                ImgUrl = entity.File.Upload(env, @"\Upload\CategoryImages\"),
                UpdatedDate = DateTime.Now,
                CreatedDate = DateTime.Now
            };

            var result = await _rep.CreateAsync(newCategory);
            await _rep.SaveChangesAsync();

            return result;
        }

        public async Task<IQueryable<Category>> ReadAsync(Expression<Func<Category, bool>>? expression = null, Expression<Func<Category, object>>? expressionOrder = null, bool isDescending = false, params string[] includes)
        {
            var result = await _rep.ReadAsync();

            return result;
        }

        public async Task<Category> ReadAsync(int Id)
        {
            if (Id <= 0 || Id == null) throw new NegativeIdException();

            var result = await _rep.ReadAsync(Id);

            if (result is null) throw new CategoryNotFoundException();


            return result;
        }

        public async Task<Category> UpdateAsync(UpdateCategoryDTO entity, string env)
        {
            if (entity.Id <= 0 || entity.Id == null) throw new NegativeIdException();

            Category oldCategory = await _rep.ReadAsync(entity.Id);

            if(oldCategory is null) throw new CategoryNotFoundException();

            FileManager.Delete(oldCategory.ImgUrl, env, @"\Upload\CategoryImages\");
            oldCategory.ImgUrl = entity.File.Upload(env, @"\Upload\CategoryImages\");
            oldCategory.Name = entity.Name;
            oldCategory.UpdatedDate = DateTime.Now;
            oldCategory.CreatedDate = oldCategory.CreatedDate;
            
            var result = await _rep.UpdateAsync(oldCategory);
            await _rep.SaveChangesAsync();

            return result;
        }

        public async Task<Category> DeleteAsync(DeleteCategoryDTO entity)
        {
            if (entity.Id <= 0 || entity.Id == null) throw new NegativeIdException();

            Category oldCategory = await _rep.ReadAsync(entity.Id);

            if (oldCategory is null) throw new CategoryNotFoundException();


            await _rep.DeleteAsync(oldCategory);
            await _rep.SaveChangesAsync();

            return oldCategory;
        }
    }
}
