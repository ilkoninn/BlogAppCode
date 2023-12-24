﻿using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Intefaces
{
    public interface ICategoryService
    {
        Task<ReadCategoryDTO> ReadAsync(
            Expression<Func<Category, bool>>? expression = null,
            Expression<Func<Category, object>>? expressionOrder = null,
            bool isDescending = false,
            params string[] includes
            );
        Task<ReadCategoryDTO> ReadAsync(int Id);
        Task<Category> CreateAsync(CreateCategoryDTO entity);
        Task<Category> UpdateAsync(UpdateCategoryDTO entity);
        Task<Category> DeleteAsync(DeleteCategoryDTO entity);
    }
}
