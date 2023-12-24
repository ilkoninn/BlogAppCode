using AutoMapper;
using BlogApp.Business.DTOs.CategoryDTOs;
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
            Category newCategory = new() 
            {
                Name = entity.Name,
                ImgUrl = entity.File.Upload(env, @"\Upload\CategoryImages\")
            };

            var result = await _rep.CreateAsync(newCategory);
            await _rep.SaveChangesAsync();

            return result;
        }

        public async Task<IQueryable<Category>> ReadAsync(Expression<Func<Category, bool>>? expression = null, Expression<Func<Category, object>>? expressionOrder = null, bool isDescending = false, params string[] includes)
        {
            return await _rep.ReadAsync();
        }

        public async Task<Category> ReadAsync(int Id)
        {
            return await _rep.ReadAsync(Id);
        }

        public async Task<Category> UpdateAsync(UpdateCategoryDTO entity, string env)
        {

            Category oldCategory = await _rep.ReadAsync(entity.Id);

            FileManager.Delete(oldCategory.ImgUrl, env, @"\Upload\CategoryImages\");
            oldCategory.ImgUrl = entity.File.Upload(env, @"\Upload\CategoryImages\");
            oldCategory.Name = entity.Name;
            
            var result = await _rep.UpdateAsync(oldCategory);
            await _rep.SaveChangesAsync();

            return result;
        }

        public async Task<Category> DeleteAsync(DeleteCategoryDTO entity)
        {
            Category oldCategory = await _rep.ReadAsync(entity.Id);
            
            await _rep.DeleteAsync(oldCategory);
            await _rep.SaveChangesAsync();

            return oldCategory;
        }
    }
}
