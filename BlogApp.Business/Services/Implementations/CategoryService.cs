using AutoMapper;
using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Business.Services.Intefaces;
using BlogApp.Core.Entities;
using BlogApp.DAL.Repositories.Interfaces;
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

        public async Task<Category> CreateAsync(CreateCategoryDTO entity)
        {
            Category newCategory = _mapper.Map<Category>(entity);

            _rep.CreateAsync(newCategory);
            _rep.SaveChangesAsync();

            return newCategory;
        }

        public async Task<ReadCategoryDTO> ReadAsync(Expression<Func<Category, bool>>? expression = null, Expression<Func<Category, object>>? expressionOrder = null, bool isDescending = false, params string[] includes)
        {
            ReadCategoryDTO read = new()
            {
                Categories = _rep.ReadAsync()
            };

            return read;
        }

        public async Task<ReadCategoryDTO> ReadAsync(int Id)
        {
            ReadCategoryDTO readOne = new()
            {
                Category = await _rep.ReadAsync(Id),
            };

            return readOne;
        }

        public async Task<Category> UpdateAsync(UpdateCategoryDTO entity)
        {
            Category oldCategory = await _rep.ReadAsync(entity.Id);
            _mapper.Map(entity, oldCategory);

            _rep.UpdateAsync(oldCategory);
            _rep.SaveChangesAsync();

            return oldCategory;
        }

        public async Task<Category> DeleteAsync(DeleteCategoryDTO entity)
        {
            Category oldCategory = await _rep.ReadAsync(entity.Id);

            _rep.DeleteAsync(oldCategory);
            _rep.SaveChangesAsync();

            return oldCategory;
        }
    }
}
