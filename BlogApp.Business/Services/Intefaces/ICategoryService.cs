using BlogApp.Business.DTOs.CategoryDTOs;
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
        Task<IQueryable<Category>> ReadAsync(
            Expression<Func<Category, bool>>? expression = null,
            Expression<Func<Category, object>>? expressionOrder = null,
            bool isDescending = false,
            params string[] includes
            );
        Task<Category> ReadAsync(int Id);
        Task<Category> CreateAsync(CreateCategoryDTO entity, string env);
        Task<Category> UpdateAsync(UpdateCategoryDTO entity, string env);
        Task<Category> DeleteAsync(DeleteCategoryDTO entity);
    }
}
