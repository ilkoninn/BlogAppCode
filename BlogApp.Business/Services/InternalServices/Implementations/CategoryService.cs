using AutoMapper;
using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Business.Exceptions;
using BlogApp.Business.Exceptions.Common;
using BlogApp.Business.Services.InternalServices.Intefaces;
using BlogApp.Core.Entities;
using BlogApp.DAL.Repositories.Interfaces;
using DianaWebApp.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.InternalServices.Implementations
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
            if (entity is null) throw new ObjectNullException();

            Category newCategory = new()
            {
                Name = entity.Name,
                ParentCategoryId = entity.ParentCategoryId,
                UpdatedDate = DateTime.Now,
                CreatedDate = DateTime.Now
            };

            var result = await _rep.CreateAsync(newCategory);
            await _rep.SaveChangesAsync();

            return result;
        }

        public async Task<ICollection<ReadCategoryDTO>> ReadAsync()
        {
            var result = await _rep.ReadAsync();

            var query = _mapper.Map<ICollection<ReadCategoryDTO>>(result.Include(x => x.ChildCategories));

            return query;
        }

        public async Task<DetailCategoryDTO> ReadIdAsync(int Id)
        {
            if (Id <= 0 || Id == null) throw new NegativeIdException();

            var result = await _rep.ReadIdAsync(Id, entityIncludes: "ChildCategories");

            if (result is null) throw new ObjectNotFoundException();


            return _mapper.Map<DetailCategoryDTO>(result);
        }

        public async Task<Category> UpdateAsync(UpdateCategoryDTO entity, string env)
        {
            if (entity.Id <= 0 || entity.Id == null ||
                entity.ParentCategoryId <= 0) throw new NegativeIdException();

            Category oldCategory = await _rep.ReadIdAsync(entity.Id);

            if (oldCategory is null) throw new ObjectNotFoundException();

            oldCategory.Name = entity.Name;
            oldCategory.ParentCategoryId = entity.ParentCategoryId;
            oldCategory.UpdatedDate = DateTime.Now;
            oldCategory.CreatedDate = oldCategory.CreatedDate;

            var result = await _rep.UpdateAsync(oldCategory);
            await _rep.SaveChangesAsync();

            return result;
        }

        public async Task<Category> DeleteAsync(int Id)
        {
            if (Id <= 0 || Id == null) throw new NegativeIdException();

            Category oldCategory = await _rep.ReadIdAsync(Id);

            if (oldCategory is null) throw new ObjectNotFoundException();

            foreach (var item in await _rep.ReadAsync())
            {
                if (item.ParentCategoryId == oldCategory.Id)
                {
                    item.ParentCategoryId = null;
                }
            }

            await _rep.DeleteAsync(Id);
            await _rep.SaveChangesAsync();

            return oldCategory;
        }
    }
}
